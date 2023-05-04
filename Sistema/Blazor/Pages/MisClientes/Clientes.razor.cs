using Blazor.Interfaces;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Blazor.Pages.MisClientes
{
    public partial class Clientes
    {
        [Inject] private IClienteServicio clienteServicio { get; set; }

        private IEnumerable<Cliente> lista { get; set; }

        protected override async Task OnInitializedAsync()
        {
            lista = await clienteServicio.GetListaAsync();
        }
    }
}
