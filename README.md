# Sistema de Agendamento de Notificações 

Este é um ecossistema backend distribuído e de alta resiliência construído em **.NET 9 (C#)**. Organizado no formato de **Monorepo**, o projeto simula um motor corporativo de agendamento e disparo de alertas assíncronos em segundo plano.

---

## Arquitetura do Sistema

O sistema é dividido em dois microsserviços independentes que coexistem dentro da mesma Solution, comunicando-se via HTTP:

* **`SistemaNotificacoes.API`**: Uma Minimal API RESTful de alta performance encarregada de receber os payloads JSON de agendamento, validar os dados e gerenciar o armazenamento inicial.
* **`SistemaNotificacoes.Worker`**: Um Worker Service (*Background Service*) desacoplado que atua como um motor de busca contínuo, realizando varreduras (polling) na API a cada 5 segundos para processar e despachar as notificações na janela de tempo correta.

---

## Tecnologias Utilizadas

* **Linguagem:** C# 13
* **Runtime:** .NET 9.0 SDK
* **Framework Web:** ASP.NET Core (Minimal APIs)
* **Processamento de Background:** Worker Services (`BackgroundService`)
* **Documentação Nativa:** OpenAPI v1 (.NET 9 OpenAPI Support)

---

##  Estrutura de Pastas (Monorepo)

```text
SistemaNotificacoes/
├── SistemaNotificacoes.sln         # Arquivo de solução que amarra os projetos
├── .gitignore                      # Ignore estruturado para o ecossistema .NET
├── README.md                       # Documentação principal do projeto
│
├── SistemaNotificacoes.API/        # Microsserviço de Entrada (API HTTP)
│   ├── Program.cs                  # Pipeline do Builder, Middlewares e Rotas
│   ├── Notificacao.cs              # Modelo de Domínio (Entidade)
│   └── SistemaNotificacoes.API.csproj
│
└── SistemaNotificacoes.Worker/     # Microsserviço de Processamento (Engine)
    ├── Program.cs                  # Inicialização da Hospedagem do Worker
    ├── Worker.cs                   # Lógica de Polling Resiliente (HttpClient)
    └── SistemaNotificacoes.Worker.csproj
