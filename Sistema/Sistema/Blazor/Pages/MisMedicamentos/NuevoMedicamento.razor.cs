using Blazor.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Modelos;

namespace Blazor.Pages.MisMedicamentos
{
    public partial class NuevoMedicamento
    {
        [Inject] private IMedicamentoServicio medicamentoServicio { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }

        private Medicamento medicamento = new Medicamento();
        string imgUrl = string.Empty;

        private async Task SeleccionarImagen(InputFileChangeEventArgs e)
        {
            IBrowserFile imgFile = e.File;
            var buffers = new byte[imgFile.Size];
            medicamento.Imagen = buffers;
            await imgFile.OpenReadStream().ReadAsync(buffers);
            string imageType = imgFile.ContentType;
            imgUrl = $"data:{imageType};base64,{Convert.ToBase64String(buffers)}";
        }

        protected async void Guardar()
        {
            if (string.IsNullOrWhiteSpace(medicamento.idMedicamento) || string.IsNullOrWhiteSpace(medicamento.Nombre)
                || string.IsNullOrWhiteSpace(medicamento.ComponenteActivo))
            {
                return;
            }
            medicamento.idMedicamento = medicamento.idMedicamento + "M";
            bool inserto = await medicamentoServicio.NuevoAsync(medicamento);

            if (inserto)
            {
                await Swal.FireAsync("Felicidades", "Medicamento Guardado", SweetAlertIcon.Success);
                navigationManager.NavigateTo("/Medicamentos");
            }
            else
            {
                await Swal.FireAsync("Error", "No se pudo guardar el medicamento", SweetAlertIcon.Error);
            }

        }

        protected async void Cancelar()
        {
            navigationManager.NavigateTo("/Medicamentos");
        }

    }
}

enum Vias
{
    Seleccionar,
    Oral,
    IntraMuscular,
    Intravenosa
}