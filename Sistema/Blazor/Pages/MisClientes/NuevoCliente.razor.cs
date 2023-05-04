using Blazor.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Blazor.Pages.MisClientes
{
    public partial class NuevoCliente
    {
        [Inject] private IClienteServicio clienteServicio { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }

        private Cliente cliente = new Cliente();

        protected async void Guardar()
        {
            if (string.IsNullOrWhiteSpace(cliente.IdentidadCliente) || string.IsNullOrWhiteSpace(cliente.NombreCliente))
            {
                return;
            }

            bool inserto = await clienteServicio.NuevoAsync(cliente);

            if (inserto)
            {
                await Swal.FireAsync("Felicidades", "cliente Guardado", SweetAlertIcon.Success);
                navigationManager.NavigateTo("/Clientes");
            }
            else
            {
                await Swal.FireAsync("Error", "No se pudo guardar el cliente", SweetAlertIcon.Error);
            }

        }
        protected async void Cancelar()
        {
            navigationManager.NavigateTo("/Clientes");
        }
    }
}
