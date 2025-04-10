namespace FinxGestaoPacientes.Entities
{
    public class HistoricoMedicoDTO
    {
        public DateTime DataConsulta { get; set; }
        public string Diagnostico { get; set; }
        public string Tratamento { get; set; }
        public int PacienteId { get; set; }
    }
}