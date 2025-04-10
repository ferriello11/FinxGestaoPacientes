using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FinxGestaoPacientes.Entities;
using FinxGestaoPacientes.Services.Interfaces;
using FinxGestaoPacientes.DTO;

namespace FinxGestaoPacientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HistoricoMedicoController : ControllerBase
    {
        private readonly IHistoricoMedicoService _historicoMedicoService;

        public HistoricoMedicoController(IHistoricoMedicoService historicoMedicoService)
        {
            _historicoMedicoService = historicoMedicoService;
        }

        [HttpGet("paciente/{pacienteId}")]
        public async Task<ActionResult<IEnumerable<HistoricoMedico>>> ObterPorPacienteId(int pacienteId)
        {
            var historicos = await _historicoMedicoService.ObterPorPacienteIdAsync(pacienteId);
            if (!historicos.Any())
                return NotFound(new { mensagem = "Nenhum histórico médico encontrado para este paciente." });

            return Ok(historicos);
        }

        [HttpPost]
        public async Task<ActionResult> Adicionar(HistoricoMedicoDTO historicoMedico)
        {
            if (historicoMedico == null)
                return BadRequest(new { mensagem = "Objeto inválido." });

            var (sucesso, mensagem) = await _historicoMedicoService.AdicionarAsync(historicoMedico);
            if (!sucesso)
                return BadRequest(new { mensagem });

            return Ok(new { mensagem = "Histórico médico cadastrado com sucesso." });
        }
    }
}
