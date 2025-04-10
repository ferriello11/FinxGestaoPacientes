using FinxGestaoPacientes.Data;
using FinxGestaoPacientes.Entities;
using FinxGestaoPacientes.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinxGestaoPacientes.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly ApplicationDbContext _context;

        public PacienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Paciente>> ObterTodosAsync()
        {
            return await _context.Pacientes.ToListAsync();
        }

        public async Task<Paciente> ObterPorIdAsync(int id)
        {
            return await _context.Pacientes.FindAsync(id);
        }

        public async Task<bool> ObterPorCpfAsync(string cpf)
        {
            return await _context.Pacientes.AnyAsync(p => p.CPF == cpf);
        }

        public async Task<bool> AdicionarAsync(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> AtualizarAsync(Paciente paciente)
        {
            var pacienteExistente = await _context.Pacientes.FirstOrDefaultAsync(p => p.PacienteId == paciente.PacienteId);

            pacienteExistente.Nome = paciente.Nome;
            pacienteExistente.CPF = paciente.CPF;
            pacienteExistente.Endereco = paciente.Endereco;
            pacienteExistente.DataNascimento = paciente.DataNascimento;

            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task RemoverAsync(int id)
        {
            var paciente = await ObterPorIdAsync(id);
            if (paciente != null)
            {
                _context.Pacientes.Remove(paciente);
                await _context.SaveChangesAsync();
            }
        }
    }

}
