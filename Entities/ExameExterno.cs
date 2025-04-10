namespace FinxGestaoPacientes.Entities
{
    public class ExameExterno
    {
        public int ExameId { get; set; }
        public int PacienteId { get; set; }
        public string NomeExame { get; set; }
        public DateTime DataExame { get; set; }
        public string Resultado { get; set; }
    }
}
