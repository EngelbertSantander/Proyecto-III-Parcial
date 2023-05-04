using Blazor.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Blazor.Pages.MisClientes
{
    public partial class EditarClientes
    {
        [Inject] private IClienteServicio clienteServicio { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }

        private Cliente cliente = new Cliente();
        [Parameter] public string IdentidadCliente { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(IdentidadCliente))
            {
                cliente = await clienteServicio.GetPorIdentidadAsync(IdentidadCliente);
            }
        }

        protected async void Guardar()
        {
            if (string.IsNullOrWhiteSpace(cliente.IdentidadCliente) || string.IsNullOrWhiteSpace(cliente.NombreCliente))
            {
                return;
            }

            bool edito = await clienteServicio.ActualizarAsync(cliente);

            if (edito)
            {
                await Swal.FireAsync("Felicidades", "Cliente Actualizado", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "No se pudo actualizar el cliente", SweetAlertIcon.Error);
            }
            navigationManager.NavigateTo("/Clientes");
        }
        protected async void Cancelar()
        {
            navigationManager.NavigateTo("/Clientes");
        }

    }
}
