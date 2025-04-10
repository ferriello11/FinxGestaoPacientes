using System.Collections.Generic;
using System.Threading.Tasks;
using FinxGestaoPacientes.Entities;

namespace FinxGestaoPacientes.Services.Interfaces
{
    public interface IBrasilApiService
    {
        Task<IEnumerable<ExameExterno>> ObterExamesExternosAsync(int pacienteId);
    }
}
