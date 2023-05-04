using Blazor.Interfaces;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Blazor.Pages.MisMedicamentos
{
    public partial class Medicamentos
    {
        [Inject] private IMedicamentoServicio medicamentoServicio { get; set; }
        private IEnumerable<Medicamento> lista { get; set; }
        protected override async Task OnInitializedAsync()
        {
            lista = await medicamentoServicio.GetListaAsync();
        }
    }
}
