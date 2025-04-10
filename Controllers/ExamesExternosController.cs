using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FinxGestaoPacientes.Services.Interfaces;
using FinxGestaoPacientes.Entities;

namespace FinxGestaoPacientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExamesExternosController : ControllerBase
    {
        private readonly IBrasilApiService _brasilApiService;
        private readonly IPacienteService _pacienteService;

        public ExamesExternosController(IBrasilApiService brasilApiService, IPacienteService pacienteService)
        {
            _brasilApiService = brasilApiService;
            _pacienteService = pacienteService;
        }

        [HttpGet("paciente/{pacienteId}")]
        public async Task<ActionResult<IEnumerable<ExameExterno>>> ObterExamesExternos(int pacienteId)
        {
            var existePaciente = await _pacienteService.ObterPorIdAsync(pacienteId);

            if (existePaciente == null)
                return BadRequest(new { mensagem = "Nenhum Paciente encontrado" });

            var exames = await _brasilApiService.ObterExamesExternosAsync(pacienteId);
            if (exames == null)
                return BadRequest(new { mensagem = "Nenhum Exames Externos Encontrado" });

            return Ok(exames);
        }
    }
}
