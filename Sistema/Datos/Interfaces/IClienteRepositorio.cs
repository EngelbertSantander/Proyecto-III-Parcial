using Modelos;

namespace Datos.Interfaces
{
    public interface IClienteRepositorio
    {
        Task<bool> NuevoAsync(Cliente cliente);
        Task<bool> ActualizarAsync(Cliente cliente);
        Task<IEnumerable<Cliente>> GetListaAsync();
        Task<Cliente> GetPorIdentidadAsync(string IdentidadCliente);
        Task<Cliente> GetPorRTNAsync(string RTNCliente);
    }
}
