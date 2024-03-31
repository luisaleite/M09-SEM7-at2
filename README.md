# Conceitos Aprendidos:

1. **Observabilidade em sistemas distribuídos**: Observabilidade refere-se à capacidade de monitorar e analisar a telemetria sobre o estado de cada componente de um sistema distribuído, observando mudanças no desempenho e diagnosticando por que essas mudanças ocorrem. É composta por três pilares principais: logs, métricas e rastreamento distribuído.
2. **Componentes da Observabilidade**:
    - **Logs**: Registram operações individuais, como solicitações de entrada, falhas em componentes específicos ou pedidos feitos.
    - **Métricas**: Contadores de medição, como número de solicitações concluídas, solicitações ativas ou histograma da latência da solicitação.
    - **Rastreamento Distribuído**: Rastreia solicitações e atividades entre componentes em um sistema distribuído para identificar onde o tempo é gasto e rastrear falhas específicas.

__________________________________________

1. **OpenTelemetry (OTel)**: framework de observabilidade open source com o qual as equipes de desenvolvimento podem gerar, processar e transmitir dados de telemetria em um formato unificado.
2. **Implementação .NET do OpenTelemetry**: A implementação do OpenTelemetry para o ambiente .NET difere um pouco de outras plataformas, pois o .NET já oferece APIs nativas para registro de logs, métricas e atividades. Isso significa que o OTel não precisa fornecer suas próprias APIs para os desenvolvedores de bibliotecas utilizarem. Em vez disso, a implementação do OpenTelemetry para .NET utiliza essas APIs nativas da plataforma para instrumentar as aplicações.

________________________________________

1. **Prometheus:** Trata-se de uma ferramenta de monitoramento de código aberto, desenvolvida pela [SoundCloud](https://developers.soundcloud.com/blog/prometheus-monitoring-at-soundcloud). O Prometheus tem como objetivo monitorar e alertar sobre a disponibilidade e o desempenho dos serviços de computação distribuída. Desde então, o Prometheus se tornou um dos softwares de monitoramento mais populares no ecossistema da nuvem.
2. **Grafana:** O Grafana é uma plataforma para visualizar e analisar métricas por meio de gráficos. Ele tem suporte para diversos tipos de bancos de dados — tanto gratuitos quanto pagos —, e pode ser instalado em qualquer sistema operacional.
3. **Jaeger:** Jaeger mapeia o fluxo de solicitações e dados à medida que atravessam um sistema distribuído. Essas solicitações podem fazer chamadas para vários serviços, o que pode introduzir atrasos ou erros próprios. Jaeger conecta os pontos entre esses componentes díspares, ajudando a identificar gargalos de desempenho, solucionar erros e melhorar a confiabilidade geral do aplicativo. Jaeger é 100% open source, nativo da nuvem e infinitamente.

# **Código e Execução**

Seguindo o passo a passo fornecido pelo link, criei um projeto com o comando:

```jsx
jsxCopy code
dotnet new web
```

Nele, substituí o código do arquivo Program.cs pelos fornecidos no link.

Na parte do Prometheus, configurei-o normalmente, adicionando no arquivo de configurações a porta para a qual estava meu servidor.

Ao rodá-lo no navegador, obtenho esses dados de métricas:

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/61dd648e-b361-4730-9aba-30fc16889c48/ae1467ce-f867-45d9-bc84-640cd0900d47/Untitled.jpeg)

E na própria plataforma do Prometheus, no link http://localhost:9090/metrics, apresenta-me esse gráfico:

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/61dd648e-b361-4730-9aba-30fc16889c48/1e15ccab-f8b9-4445-bc1a-0ae93dd49483/Untitled.jpeg)

Fonte

[https://www.linkedin.com/pulse/net-6-com-opentelemetry-e-prometheusgrafana-jackson-wendel-santos-sá/?originalSubdomain=pt](https://www.linkedin.com/pulse/net-6-com-opentelemetry-e-prometheusgrafana-jackson-wendel-santos-s%C3%A1/?originalSubdomain=pt)

https://www.opservices.com.br/monitoramento-prometheus/

https://www.opservices.com.br/grafana/

https://www.jaegertracing.io/
