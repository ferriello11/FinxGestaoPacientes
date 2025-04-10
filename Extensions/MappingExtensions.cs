using FinxGestaoPacientes.Entities;

namespace FinxGestaoPacientes.Extensions
{
    public static class MappingExtensions
    {
        public static Paciente ToPaciente(this PacienteDTO pacienteDto)
        {
            var paciente = new Paciente
            {
                Nome = pacienteDto.Nome,
                DataNascimento = pacienteDto.DataNascimento,
                CPF = pacienteDto.CPF,
                Endereco = pacienteDto.Endereco,
            };

            if (pacienteDto is PacienteUpdateDTO updateDto)
            {
                paciente.PacienteId = updateDto.PacienteId;
            }

            return paciente;
        }

        public static HistoricoMedico ToHistoricoMedico(this HistoricoMedicoDTO historicoMedicoDto)
        {
            return new HistoricoMedico
            {
                DataConsulta = historicoMedicoDto.DataConsulta,
                Diagnostico = historicoMedicoDto.Diagnostico,
                Tratamento = historicoMedicoDto.Tratamento,
                PacienteId = historicoMedicoDto.PacienteId
            };
        }
    }
}
