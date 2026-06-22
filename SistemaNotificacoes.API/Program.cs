using SistemaNotificacoes.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

List<Notificacao> bancoEmMemoria = new();

app.MapPost("/api/notificacoes/agendar", (Notificacao novaNotificacao) =>
{
    bancoEmMemoria.Add(novaNotificacao);

    return Results.Ok(new
    {
        Mensagem = novaNotificacao.Mensagem,
        Id = novaNotificacao.Id,
        HorarioAgendado = novaNotificacao.DataAgendamento

    });
});

app.MapGet("/api/notificacoes/agendar", () =>
{
    return Results.Ok(bancoEmMemoria);
});

app.Run();