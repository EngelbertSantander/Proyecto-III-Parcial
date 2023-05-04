using Blazor.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Blazor.Pages.MiLaboratorio
{
    public partial class TomaMuestras
    {
        [Inject] private IExamenServicio examenServicio { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }
        private Examen examen = new Examen();
        private IEnumerable<Examen> listado { get; set; }

        protected override async Task OnInitializedAsync()
        {
            listado = await examenServicio.GetListaTipoExamenAsync();
        }

        protected async void Guardar()
        {
            examen.FechaTomaMuestra = DateTime.Now;
            examen.Pagado = false;
            examen.Estado = "Tomada";
            string nombre = examen.TipoExamen;
            examen.Precio = await examenServicio.TraerPrecioAsync(nombre);

            bool edito = await examenServicio.NuevaMuestraAsync(examen);

            if (edito)
            {
                int num = await examenServicio.UltimoRegistro();
                await Swal.FireAsync("Felicidades", "Muestra guardada, presentarse a caja y pagar el examen Num:" + num + " el valor a cancelar es de:" + examen.Precio + " Lps", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "No se pudo guardar la muestra", SweetAlertIcon.Error);
            }

            navigationManager.NavigateTo("/");
        }
    }
}
