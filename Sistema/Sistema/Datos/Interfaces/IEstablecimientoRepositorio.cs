using Modelos;

namespace Datos.Interfaces
{
    public interface IEstablecimientoRepositorio
    {
        Task<bool> ActualizarAsync(Establecimiento establecimiento);
        Task<IEnumerable<Establecimiento>> GetListaAsync();
        Task<Establecimiento> GetPorCodigoAsync(string RTN);
        Task<Establecimiento> UnicoRegistroAsync();
    }
}
