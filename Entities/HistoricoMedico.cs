using System.Text.Json.Serialization;

namespace FinxGestaoPacientes.Entities
{
    public class HistoricoMedico
    {
        [JsonIgnore]
        public int HistoricoMedicoId { get; set; }
        [JsonIgnore]
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public DateTime DataConsulta { get; set; }
        public string Diagnostico { get; set; }
        public string Tratamento { get; set; }
    }
}
