using FinxGestaoPacientes.Data;
using FinxGestaoPacientes.Entities;
using FinxGestaoPacientes.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinxGestaoPacientes.Repositories
{

    public class HistoricoMedicoRepository : IHistoricoMedicoRepository
    {
        private readonly ApplicationDbContext _context;

        public HistoricoMedicoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HistoricoMedico>> ObterPorPacienteIdAsync(int pacienteId)
        {
            return await _context.HistoricoMedicos
                .Where(h => h.PacienteId == pacienteId)
                .Include(h => h.Paciente)
                .ToListAsync();
        }

        public async Task<bool> AdicionarAsync(HistoricoMedico historicoMedico)
        {
            await _context.HistoricoMedicos.AddAsync(historicoMedico);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }
    }

}
