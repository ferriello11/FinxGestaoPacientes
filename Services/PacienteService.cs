using FinxGestaoPacientes.DTO;
using FinxGestaoPacientes.Entities;
using FinxGestaoPacientes.Extensions;
using FinxGestaoPacientes.Repositories.Interfaces;
using FinxGestaoPacientes.Services.Interfaces;

namespace FinxGestaoPacientes.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task<IEnumerable<Paciente>> ObterTodosAsync()
        {
            return await _pacienteRepository.ObterTodosAsync();
        }

        public async Task<Paciente?> ObterPorIdAsync(int id)
        {
            return await _pacienteRepository.ObterPorIdAsync(id);
        }

        public async Task<(bool existe, string mensagem)> ObterPorCpfAsync(string cpf)
        {
            var existe = await _pacienteRepository.ObterPorCpfAsync(cpf);
            return existe
                ? (true, "CPF já cadastrado.")
                : (false, string.Empty);
        }

        public async Task<(bool sucesso, string mensagem)> AdicionarAsync(PacienteDTO pacienteDto)
        {
            var (cpfExiste, mensagem) = await ObterPorCpfAsync(pacienteDto.CPF);
            if (cpfExiste)
                return (false, mensagem);

            var paciente = pacienteDto.ToPaciente();
            var sucesso = await _pacienteRepository.AdicionarAsync(paciente);
            return sucesso
                ? (true, string.Empty)
                : (false, "Erro ao adicionar paciente.");
        }

        public async Task<(bool sucesso, string mensagem)> AtualizarAsync(PacienteUpdateDTO pacienteDto)
        {
            var existente = await _pacienteRepository.ObterPorIdAsync(pacienteDto.PacienteId);
            if (existente == null)
                return (false, "Paciente não encontrado.");

            var paciente = pacienteDto.ToPaciente();
            var atualizado = await _pacienteRepository.AtualizarAsync(paciente);
            return atualizado
                ? (true, string.Empty)
                : (false, "Erro ao atualizar paciente.");
        }

        public async Task<(bool sucesso, string mensagem)> RemoverAsync(int id)
        {
            var existente = await _pacienteRepository.ObterPorIdAsync(id);
            if (existente == null)
                return (false, "Paciente não encontrado.");

            await _pacienteRepository.RemoverAsync(id);
            return (true, string.Empty);
        }
    }
}
