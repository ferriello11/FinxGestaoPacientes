using FinxGestaoPacientes.Entities;

namespace FinxGestaoPacientes.Repositories.Interfaces
{
    public interface IHistoricoMedicoRepository
    {
        Task<IEnumerable<HistoricoMedico>> ObterPorPacienteIdAsync(int pacienteId);
        Task<bool> AdicionarAsync(HistoricoMedico historicoMedico);
    }
}