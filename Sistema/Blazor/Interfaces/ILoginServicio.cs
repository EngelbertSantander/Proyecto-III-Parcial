using Modelos;

namespace Blazor.Interfaces
{
    public interface ILoginServicio
    {
        public Task<bool> ValidarUsuario(Login login);
    }
}
