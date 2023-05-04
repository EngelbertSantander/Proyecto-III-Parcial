using Modelos;

namespace Datos.Interfaces
{
    public interface ILoginRepositorio
    {
        public Task<bool> ValidarUsuario(Login login);
    }
}
