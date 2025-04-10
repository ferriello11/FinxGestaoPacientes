namespace FinxGestaoPacientes.Extensions
{
    public class ResultadoOperacao<T>
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public T? Dados { get; set; }

        public static ResultadoOperacao<T> SucessoComDados(T dados, string mensagem = "") =>
            new ResultadoOperacao<T> { Sucesso = true, Dados = dados, Mensagem = mensagem };

        public static ResultadoOperacao<T> Falha(string mensagem) =>
            new ResultadoOperacao<T> { Sucesso = false, Mensagem = mensagem };
    }

}