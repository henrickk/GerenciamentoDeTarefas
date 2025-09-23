namespace Gerenciamento.Business.Notificacoes
{
    public class Notificacao
    {
        public string Mensagens { get; set; }

        public Notificacao(string mensagem)
        {
            Mensagens = mensagem;
        }
    }
}
