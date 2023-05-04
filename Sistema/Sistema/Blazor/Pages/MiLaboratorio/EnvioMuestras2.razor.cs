using Blazor.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Blazor.Pages.MiLaboratorio
{
    public partial class EnvioMuestras2
    {
        [Inject] private IExamenServicio examenServicio { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }

        [Parameter] public string IdExamen { get; set; }

        private Examen examen = new Examen();
        protected override async Task OnInitializedAsync()
        {
            examen = await examenServicio.BuscarPorIdAsync(IdExamen);
            if (examen.Pagado)
            {
                examen.Estado = "Enviada";
                examen.FechaEnvio = DateTime.Now;
                examen.FechaDevolucion = null;

                SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "¿Seguro que desea enviar esta muestra?",
                    Icon = SweetAlertIcon.Question,
                    ShowCancelButton = true,
                    ConfirmButtonText = "Aceptar",
                    CancelButtonText = "Cancelar"
                });
                if (!string.IsNullOrEmpty(result.Value))
                {
                    await examenServicio.ActualizarAsync(examen);

                }
            }
            else
            {
                await Swal.FireAsync("Error", "No se puede enviar, aun no ha sido pagada", SweetAlertIcon.Error);
            }
            navigationManager.NavigateTo("/EnvioMuestras");
        }

    }
}
