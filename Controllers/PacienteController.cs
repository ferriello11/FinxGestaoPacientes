using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FinxGestaoPacientes.Entities;
using FinxGestaoPacientes.Services.Interfaces;

namespace FinxGestaoPacientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        public PacientesController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paciente>>> ObterTodos()
        {
            var pacientes = await _pacienteService.ObterTodosAsync();

            if (!pacientes.Any())
                return NotFound(new { mensagem = "Nenhum paciente encontrado." });

            return Ok(pacientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> ObterPorId(int id)
        {
            var paciente = await _pacienteService.ObterPorIdAsync(id);
            if (paciente == null)
                return NotFound(new { mensagem = "Paciente não encontrado." });

            return Ok(paciente);
        }

        [HttpPost]
        public async Task<ActionResult> Adicionar(PacienteDTO pacienteDTO)
        {
            var (sucesso, mensagem) = await _pacienteService.AdicionarAsync(pacienteDTO);

            if (!sucesso)
                return BadRequest(new { mensagem });

            return Created(string.Empty, new { mensagem = "Paciente cadastrado com sucesso." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, PacienteUpdateDTO pacienteDTO)
        {
            if (id != pacienteDTO.PacienteId)
                return BadRequest(new { mensagem = "ID do caminho e do corpo estão diferentes." });

            var (sucesso, mensagem) = await _pacienteService.AtualizarAsync(pacienteDTO);
            if (!sucesso)
                return BadRequest(new { mensagem });

            return Ok(new { mensagem = "Paciente atualizado com sucesso." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            var (sucesso, mensagem) = await _pacienteService.RemoverAsync(id);
            if (!sucesso)
                return BadRequest(new { mensagem });

            return Ok(new { mensagem = "Paciente removido com sucesso" });
        }
    }
}