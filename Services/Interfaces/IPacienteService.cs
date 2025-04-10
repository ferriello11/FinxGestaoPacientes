using FinxGestaoPacientes.DTO;
using FinxGestaoPacientes.Entities;

namespace FinxGestaoPacientes.Services.Interfaces
{
    public interface IPacienteService
    {
        Task<IEnumerable<Paciente>> ObterTodosAsync();
        Task<Paciente?> ObterPorIdAsync(int id);
        Task<(bool existe, string mensagem)> ObterPorCpfAsync(string cpf);
        Task<(bool sucesso, string mensagem)> AdicionarAsync(PacienteDTO pacienteDto);
        Task<(bool sucesso, string mensagem)> AtualizarAsync(PacienteUpdateDTO paciente);
        Task<(bool sucesso, string mensagem)> RemoverAsync(int id);
    }

}