using Modelos;

namespace Blazor.Interfaces
{
    public interface ILaboratorioRepositorio
    {
        Task<bool> ActualizarAsync(Laboratorio laboratorio);
        Task<bool> NuevoAsync(Examen examen);

        Task<Cliente> GetPorIdentidadAsync(string IdentidadCliente);
    }

}
