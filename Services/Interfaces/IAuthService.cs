using FinxGestaoPacientes.Entities;

namespace FinxGestaoPacientes.Services.Interfaces
{
    public interface IAuthService
    {
        string GerarToken(Usuario usuario);
    }
}
