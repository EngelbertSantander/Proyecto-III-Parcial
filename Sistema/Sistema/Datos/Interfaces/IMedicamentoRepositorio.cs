using Modelos;

namespace Datos.Interfaces
{
    public interface IMedicamentoRepositorio
    {
        Task<bool> NuevoAsync(Medicamento medicamento);
        Task<bool> ActualizarAsync(Medicamento medicamento);
        Task<IEnumerable<Medicamento>> GetListaAsync();
        Task<Medicamento> GetPorCodigoAsync(string idMedicamento);
        Task<Medicamento> GetPorNombreAsync(string Nombre);

    }
}
