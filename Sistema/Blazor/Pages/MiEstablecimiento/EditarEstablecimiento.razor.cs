using Blazor.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Blazor.Pages.MiEstablecimiento
{
    public partial class EditarEstablecimiento
    {
        [Inject] private IEstablecimientoServicio establecimientoServicio { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }

        private Establecimiento establecimiento = new Establecimiento();

        [Parameter] public string RTN { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(RTN))
            {
                establecimiento = await establecimientoServicio.GetPorCodigoAsync(RTN);
            }
        }

        protected async void Guardar()
        {
            if (string.IsNullOrWhiteSpace(establecimiento.RTN) || string.IsNullOrWhiteSpace(establecimiento.NombreEstablecimiento))
            {
                return;
            }

            bool edito = await establecimientoServicio.ActualizarAsync(establecimiento);

            if (edito)
            {
                await Swal.FireAsync("Felicidades", "Establecimiento Actualizado", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "No se pudo actualizar el establecimiento", SweetAlertIcon.Error);
            }
            navigationManager.NavigateTo("/Establecimiento");
        }
        protected async void Cancelar()
        {
            navigationManager.NavigateTo("/Establecimiento");
        }

    }
}
