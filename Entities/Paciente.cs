using System.Text.Json.Serialization;

namespace FinxGestaoPacientes.Entities
{
    public class Paciente
    {
        [JsonIgnore]
        public int PacienteId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        [JsonIgnore]
        public ICollection<HistoricoMedico> HistoricoMedicos { get; set; }
    }
}