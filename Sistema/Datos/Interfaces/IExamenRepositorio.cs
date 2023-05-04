using Modelos;

namespace Datos.Interfaces
{
    public interface IExamenRepositorio
    {
        Task<bool> NuevaMuestraAsync(Examen examen);
        Task<double> TraerPrecioAsync(string TipoExamen);
        Task<IEnumerable<Examen>> GetListaTipoExamenAsync();
        Task<IEnumerable<Examen>> GetListaPorEstadoAsync(string Estado);
        Task<IEnumerable<Examen>> GetListaPorEstadoYIdPersonaAsync(string Estado, string IdentidadCliente);

        Task<bool> ActualizarAsync(Examen examen);
        Task<Examen> BuscarPorIdAsync(string IdExamen);

        Task<bool> CambiarEstadoDePagoAsync(int IdExamen);

        Task<int> UltimoRegistro();

    }
}
