namespace SistemaNotificacoes.API
{
    public class Notificacao
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Mensagem { get; set; }
        public string Destinatario { get; set; }
        public DateTime DataAgendamento { get; set; } // Quando o alerta deve disparar
        public bool Processado { get; set; } = false;

        public Notificacao(string mensagem, string destinatario, DateTime dataAgendamento)
        {
            Mensagem = mensagem;
            Destinatario = destinatario;
            DataAgendamento = dataAgendamento;
        }
    }
}
