using Blazor.Interfaces;
using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;

namespace Blazor.Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly Config _config;
        private IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioServicio(Config config)
        {
            _config = config;
            _usuarioRepositorio = new UsuarioRepositorio(config.CadenaConexion);
        }

        public async Task<bool> ActualizarAsync(Usuario user)
        {
            return await _usuarioRepositorio.ActualizarAsync(user);
        }

        public async Task<bool> EliminarAsync(string codigoUsuario)
        {
            return await _usuarioRepositorio.EliminarAsync(codigoUsuario);
        }

        public async Task<IEnumerable<Usuario>> GetListaAsync()
        {
            return await _usuarioRepositorio.GetListaAsync();
        }

        public async Task<Usuario> GetPorCodigoAsync(string codigoUsuario)
        {
            return await _usuarioRepositorio.GetPorCodigoAsync(codigoUsuario);
        }

        public async Task<Usuario> GetPorNombreAsync(string Nombre)
        {
            return await _usuarioRepositorio.GetPorNombreAsync(Nombre);
        }

        public async Task<bool> NuevoAsync(Usuario user)
        {
            return await _usuarioRepositorio.NuevoAsync(user);
        }
    }
}
