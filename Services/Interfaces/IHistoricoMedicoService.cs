using FinxGestaoPacientes.DTO;
using FinxGestaoPacientes.Entities;

namespace FinxGestaoPacientes.Services.Interfaces
{
    public interface IHistoricoMedicoService
    {
        Task<IEnumerable<HistoricoMedico>> ObterPorPacienteIdAsync(int pacienteId);
        Task<(bool sucesso, string? mensagem)> AdicionarAsync(HistoricoMedicoDTO historicoMedicoDTO);
    }
}