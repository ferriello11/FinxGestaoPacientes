using FinxGestaoPacientes.Entities;
using FinxGestaoPacientes.Services.Interfaces;

namespace FinxGestaoPacientes.Services
{
    public class BrasilApiService : IBrasilApiService
    {
        public async Task<IEnumerable<ExameExterno>> ObterExamesExternosAsync(int pacienteId)
        {
            var exames = new List<ExameExterno>
            {
                new ExameExterno { ExameId = 1, PacienteId = pacienteId, NomeExame = "Hemograma Completo", DataExame = DateTime.Now.AddDays(-10), Resultado = "Normal" },
                new ExameExterno { ExameId = 2, PacienteId = pacienteId, NomeExame = "Raio-X do Tórax", DataExame = DateTime.Now.AddDays(-5), Resultado = "Sem alterações" }
            };

            return await Task.FromResult(exames);
        }
    }
}
