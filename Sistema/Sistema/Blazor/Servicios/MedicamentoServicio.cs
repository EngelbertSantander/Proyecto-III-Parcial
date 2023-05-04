using Blazor.Interfaces;
using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;

namespace Blazor.Servicios
{
    public class MedicamentoServicio : IMedicamentoServicio
    {
        private readonly Config _config;
        private IMedicamentoRepositorio _medicamentoRepositorio;

        public MedicamentoServicio(Config config)
        {
            _config = config;
            _medicamentoRepositorio = new MedicamentoRepositorio(config.CadenaConexion);
        }

        public async Task<bool> ActualizarAsync(Medicamento medicamento)
        {
            return await _medicamentoRepositorio.ActualizarAsync(medicamento);
        }

        public async Task<IEnumerable<Medicamento>> GetListaAsync()
        {
            return await _medicamentoRepositorio.GetListaAsync();
        }

        public async Task<Medicamento> GetPorCodigoAsync(string idMedicamento)
        {
            return await _medicamentoRepositorio.GetPorCodigoAsync(idMedicamento);
        }

        public async Task<Medicamento> GetPorNombreAsync(string Nombre)
        {
            return await _medicamentoRepositorio.GetPorNombreAsync(Nombre);
        }

        public async Task<bool> NuevoAsync(Medicamento medicamento)
        {
            return await _medicamentoRepositorio.NuevoAsync(medicamento);
        }
    }
}
