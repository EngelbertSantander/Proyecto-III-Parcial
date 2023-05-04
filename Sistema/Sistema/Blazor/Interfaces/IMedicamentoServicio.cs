using Modelos;

namespace Blazor.Interfaces
{
    public interface IMedicamentoServicio
    {
        Task<bool> NuevoAsync(Medicamento medicamento);
        Task<bool> ActualizarAsync(Medicamento medicamento);
        Task<IEnumerable<Medicamento>> GetListaAsync();
        Task<Medicamento> GetPorCodigoAsync(string idMedicamento);
        Task<Medicamento> GetPorNombreAsync(string Nombre);
    }
}
