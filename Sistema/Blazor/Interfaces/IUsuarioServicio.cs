using Modelos;

namespace Blazor.Interfaces
{
    public interface IUsuarioServicio
    {
        Task<bool> NuevoAsync(Usuario user);
        Task<bool> ActualizarAsync(Usuario user);
        Task<bool> EliminarAsync(string codigoUsuario);
        Task<IEnumerable<Usuario>> GetListaAsync();
        Task<Usuario> GetPorCodigoAsync(string codigoUsuario);
        Task<Usuario> GetPorNombreAsync(string Nombre);
    }
}
