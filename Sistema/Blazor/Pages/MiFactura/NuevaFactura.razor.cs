namespace Blazor.Pages.MiFactura
{
    public partial class NuevaFactura
    {
        /* [Inject] private IEstablecimientoServicio establecimientoServicio { get; set; }
        [Inject] private IFacturaServicio facturaServicio { get; set; }
        [Inject] private IDetalleFacturaServicio detalleFacturaServicio { get; set; }
        [Inject] private IMedicamentoServicio medicamentoServicio { get; set; }
        [Inject] private IClienteServicio clienteServicio { get; set; }
        [Inject] private IUsuarioServicio usuarioServicio { get; set; }
        [Inject] NavigationManager navigationManager { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }
        [Inject] private IHttpContextAccessor httpContextAccessor { get; set; }
        public Factura factura = new Factura();
        private Medicamento medicamento = new Medicamento();
        private Establecimiento establecimiento = new Establecimiento();
        private Cliente cliente = new Cliente();

        private List<DetalleFactura> listaDetalleFactura = new List<DetalleFactura>();
        private int cantidad { get; set; }
        private string identidadCliente { get; set; }
        private string idMedicamento { get; set; }

        protected override async Task OnInitializedAsync()
        {

            establecimiento = await establecimientoServicio.UnicoRegistroAsync();

        }
        private async void BuscarClienteporIdentidad()
        {
            cliente = await clienteServicio.GetPorIdentidadAsync(identidadCliente);
        }
        private async void BuscarProducto()
        {
            medicamento = await medicamentoServicio.GetPorCodigoAsync(idMedicamento);
        }
        protected async Task AgregarMedicamento(MouseEventArgs args)
        {
            if (args.Detail != 0)
            {
                if (medicamento != null)
                {
                    DetalleFactura detalle = new DetalleFactura();
                    detalle.Descripcion = medicamento.ComponenteActivo;
                    detalle.IdMedicamento = medicamento.idMedicamento;
                    detalle.Cantidad = Convert.ToInt32(cantidad);
                    detalle.Precio = medicamento.Precio;
                    detalle.Total = medicamento.Precio * Convert.ToInt32(cantidad);
                    listaDetalleFactura.Add(detalle);
                    medicamento.Indicaciones = string.Empty;
                    medicamento.Precio = 0;
                    medicamento.Existencia = 0;
                    cantidad = 0;
                    idMedicamento = "0";

                    factura.SubTotal = factura.SubTotal + detalle.Total;
                    factura.ISV = factura.SubTotal * 0.15;
                    factura.Total = factura.SubTotal + factura.ISV - factura.Descuento;
                }
            }
        }

        protected async Task Guardar()
        {
            factura.IDEmpleado = httpContextAccessor.HttpContext.User.Identity.Name;
            int idFactura = await facturaServicio.Nueva(factura);
            if (idFactura == 0)
            {
                foreach (var item in listaDetalleFactura)
                {
                    item.IdFactura = idFactura;
                    await detalleFacturaServicio.Nuevo(item);
                }
                await Swal.FireAsync("Felicidades", "Factura guardada con exito", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "No se pudo guardar la factura", SweetAlertIcon.Error);
            }
        }*/

    }
}
