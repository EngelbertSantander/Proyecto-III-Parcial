using Blazor.Interfaces;
using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;

namespace Blazor.Servicios
{
    public class EstablecimientoServicio : IEstablecimientoServicio
    {
        private readonly Config _config;
        private IEstablecimientoRepositorio _EstablecimientoRepositorio;

        public EstablecimientoServicio(Config config)
        {
            _config = config;
            _EstablecimientoRepositorio = new EstablecimientoRepositorio(config.CadenaConexion);
        }

        public async Task<bool> ActualizarAsync(Establecimiento establecimiento)
        {
            return await _EstablecimientoRepositorio.ActualizarAsync(establecimiento);
        }

        public async Task<IEnumerable<Establecimiento>> GetListaAsync()
        {
            return await _EstablecimientoRepositorio.GetListaAsync();
        }

        public async Task<Establecimiento> GetPorCodigoAsync(string RTN)
        {
            return await _EstablecimientoRepositorio.GetPorCodigoAsync(RTN);
        }

        public async Task<Establecimiento> UnicoRegistroAsync()
        {
            return await _EstablecimientoRepositorio.UnicoRegistroAsync();
        }
    }
}
