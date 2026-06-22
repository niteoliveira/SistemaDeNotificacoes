using System.Net.Http.Json;
using SistemaNotificacoes.API;

namespace SistemaNotificacoes.Worker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly HttpClient _httpClient;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
        _httpClient = new HttpClient();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("O Motor de Notificações foi iniciado.");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                _logger.LogInformation("Buscando notificações agendadas na API...");
                var urlApi = "https://localhost:7123/api/notificacoes/agendar";

                var notificacoes = await _httpClient.GetFromJsonAsync<List<Notificacao>>(urlApi, stoppingToken);

                if (notificacoes != null && notificacoes.Any())
                {
                    _logger.LogWarning($"Encontrada(s) {notificacoes.Count} notificação(ões) na fila.");
                }
                else
                {
                    _logger.LogInformation("Nenhuma notificação encontrada.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao conectar na API: {ex.Message}");
            }
            await Task.Delay(5000, stoppingToken);
        }
    }

}
