using Modelos;

namespace Blazor.Interfaces
{
    public interface IExamenServicio
    {
        Task<bool> NuevaMuestraAsync(Examen examen);
        Task<double> TraerPrecioAsync(string TipoExamen);
        Task<IEnumerable<Examen>> GetListaTipoExamenAsync();
        Task<IEnumerable<Examen>> GetListaPorEstadoAsync(string Estado);
        Task<bool> ActualizarAsync(Examen examen);
        Task<Examen> BuscarPorIdAsync(string IdExamen);
        Task<bool> CambiarEstadoDePagoAsync(int IdExamen);
        Task<int> UltimoRegistro();
        Task<IEnumerable<Examen>> GetListaPorEstadoYIdPersonaAsync(string Estado, string IdentidadCliente);
    }
}
