using FinxGestaoPacientes.Entities;

namespace FinxGestaoPacientes.Repositories.Interfaces
{
    public interface IPacienteRepository
    {
        Task<IEnumerable<Paciente>> ObterTodosAsync();
        Task<Paciente> ObterPorIdAsync(int id);
        Task<bool> ObterPorCpfAsync(string cpf);
        Task<bool> AdicionarAsync(Paciente paciente);
        Task<bool> AtualizarAsync(Paciente paciente);
        Task RemoverAsync(int id);
    }
}