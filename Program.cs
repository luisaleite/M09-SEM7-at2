using System.Diagnostics;
using System.Diagnostics.Metrics;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        // Definir métricas personalizadas para o aplicativo
        using var greeterMeter = new Meter("OtPrGrYa.Example", "1.0.0");
        var countGreetings = greeterMeter.CreateCounter<int>("greetings.count", description: "Conta o número de saudações");

        // Definir fonte de atividade personalizada para o aplicativo
        using var greeterActivitySource = new ActivitySource("OtPrGrJa.Example");

        app.MapGet("/", SendGreeting);

        app.Run();

        async Task<string> SendGreeting(ILogger<Program> logger)
        {
            // Create a new Activity scoped to the method
            using var activity = greeterActivitySource.StartActivity("GreeterActivity");

            // Log a message
            logger.LogInformation("Sending greeting");

            // Increment the custom counter
            countGreetings.Add(1);

            // Add a tag to the Activity
            activity?.SetTag("greeting", "Hello World!");

            return "Hello World!";
        }

        // Configuração do OpenTelemetry e mapeamento do ponto de extremidade Prometheus
        var tracingOtlpEndpoint = builder.Configuration["OTLP_ENDPOINT_URL"];
        var otel = builder.Services.AddOpenTelemetry();

        otel.ConfigureResource(resource => resource
            .AddService(serviceName: builder.Environment.ApplicationName));

        // using OpenTelemetry.Instrumentation.AspNetCore;

        otel.WithMetrics(metrics => metrics
            .AddAspNetCoreInstrumentation()
            .AddMeter(greeterMeter.Name)
            .AddMeter("Microsoft.AspNetCore.Hosting")
            .AddMeter("Microsoft.AspNetCore.Server.Kestrel")
            .AddPrometheusExporter());

        otel.WithTracing(tracing =>
        {
            tracing.AddAspNetCoreInstrumentation();
            tracing.AddHttpClientInstrumentation();
            tracing.AddSource(greeterActivitySource.Name);
            if (tracingOtlpEndpoint != null)
            {
                tracing.AddOtlpExporter(otlpOptions =>
                {
                    otlpOptions.Endpoint = new Uri(tracingOtlpEndpoint);
                });
            }
            else
            {
                tracing.AddConsoleExporter();
            }
        });

        app.MapPrometheusScrapingEndpoint();
    }
}
