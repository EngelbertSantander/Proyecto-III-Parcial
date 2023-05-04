using Modelos;

namespace Blazor.Interfaces
{
    public interface IEstablecimientoServicio
    {
        Task<bool> ActualizarAsync(Establecimiento establecimiento);
        Task<IEnumerable<Establecimiento>> GetListaAsync();
        Task<Establecimiento> GetPorCodigoAsync(string RTN);
        Task<Establecimiento> UnicoRegistroAsync();
    }
}
