using Blazor.Interfaces;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Blazor.Pages.MiEstablecimiento
{
    public partial class Establecimientos
    {
        [Inject] private IEstablecimientoServicio establecimientoServicio { get; set; }
        private IEnumerable<Establecimiento> lista { get; set; }
        protected override async Task OnInitializedAsync()
        {
            lista = await establecimientoServicio.GetListaAsync();
        }
    }
}
