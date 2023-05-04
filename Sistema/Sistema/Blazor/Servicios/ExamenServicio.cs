using Blazor.Interfaces;
using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;

namespace Blazor.Servicios
{
    public class ExamenServicio : IExamenServicio
    {
        private readonly Config _config;
        private IExamenRepositorio examenRepositorio;

        public ExamenServicio(Config config)
        {
            _config = config;
            examenRepositorio = new ExamenRepositorio(config.CadenaConexion);
        }

        public async Task<bool> ActualizarAsync(Examen examen)
        {
            return await examenRepositorio.ActualizarAsync(examen);
        }

        public async Task<Examen> BuscarPorIdAsync(string IdExamen)
        {
            return await examenRepositorio.BuscarPorIdAsync(IdExamen);
        }

        public async Task<bool> CambiarEstadoDePagoAsync(int IdExamen)
        {
            return await examenRepositorio.CambiarEstadoDePagoAsync(IdExamen);
        }

        public async Task<IEnumerable<Examen>> GetListaPorEstadoAsync(string Estado)
        {
            return await examenRepositorio.GetListaPorEstadoAsync(Estado);
        }

        public async Task<IEnumerable<Examen>> GetListaPorEstadoYIdPersonaAsync(string Estado, string IdentidadCliente)
        {
            return await examenRepositorio.GetListaPorEstadoYIdPersonaAsync(Estado, IdentidadCliente);
        }

        public async Task<IEnumerable<Examen>> GetListaTipoExamenAsync()
        {
            return await examenRepositorio.GetListaTipoExamenAsync();
        }

        public async Task<bool> NuevaMuestraAsync(Examen examen)
        {
            return await examenRepositorio.NuevaMuestraAsync(examen);
        }

        public async Task<double> TraerPrecioAsync(string TipoExamen)
        {
            return await examenRepositorio.TraerPrecioAsync(TipoExamen);
        }

        public async Task<int> UltimoRegistro()
        {
            return await examenRepositorio.UltimoRegistro();
        }
    }
}
