using FinxGestaoPacientes.Entities;
using FinxGestaoPacientes.Extensions;
using FinxGestaoPacientes.Repositories.Interfaces;
using FinxGestaoPacientes.Services.Interfaces;

namespace FinxGestaoPacientes.Services
{
    public class HistoricoMedicoService : IHistoricoMedicoService
    {
        private readonly IHistoricoMedicoRepository _historicoMedicoRepository;
        private readonly IPacienteRepository _pacienteRepository;

        public HistoricoMedicoService(IHistoricoMedicoRepository historicoMedicoRepository, IPacienteRepository pacienteRepository)
        {
            _historicoMedicoRepository = historicoMedicoRepository;
            _pacienteRepository = pacienteRepository;
        }

        public async Task<IEnumerable<HistoricoMedico>> ObterPorPacienteIdAsync(int pacienteId)
        {
            return await _historicoMedicoRepository.ObterPorPacienteIdAsync(pacienteId);
        }

        public async Task<(bool sucesso, string? mensagem)> AdicionarAsync(HistoricoMedicoDTO historicoMedicoDTO)
        {
            var paciente = await _pacienteRepository.ObterPorIdAsync(historicoMedicoDTO.PacienteId);
            if (paciente == null)
                return (false, "Paciente não encontrado.");

            var historicoMedico = historicoMedicoDTO.ToHistoricoMedico();
            var sucesso = await _historicoMedicoRepository.AdicionarAsync(historicoMedico);

            return sucesso
                ? (true, null)
                : (false, "Não foi possível salvar o histórico médico.");
        }
    }
}