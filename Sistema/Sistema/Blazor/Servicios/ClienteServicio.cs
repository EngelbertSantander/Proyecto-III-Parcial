using Blazor.Interfaces;
using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;

namespace Blazor.Servicios
{
    public class ClienteServicio : IClienteServicio
    {
        private readonly Config _config;
        private IClienteRepositorio _ClienteRepositorio;

        public ClienteServicio(Config config)
        {
            _config = config;
            _ClienteRepositorio = new ClienteRepositorio(config.CadenaConexion);
        }

        public async Task<bool> ActualizarAsync(Cliente cliente)
        {
            return await _ClienteRepositorio.ActualizarAsync(cliente);
        }

        public async Task<IEnumerable<Cliente>> GetListaAsync()
        {
            return await _ClienteRepositorio.GetListaAsync();
        }

        public async Task<Cliente> GetPorIdentidadAsync(string IdentidadCliente)
        {
            return await _ClienteRepositorio.GetPorIdentidadAsync(IdentidadCliente);
        }

        public async Task<Cliente> GetPorRTNAsync(string RTNCliente)
        {
            return await _ClienteRepositorio.GetPorRTNAsync(RTNCliente);
        }

        public async Task<bool> NuevoAsync(Cliente cliente)
        {
            return await _ClienteRepositorio.NuevoAsync(cliente);
        }
    }
}
