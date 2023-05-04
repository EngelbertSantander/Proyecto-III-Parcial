using Blazor.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Modelos;

namespace Blazor.Pages.MiFactura
{
    public partial class Factura
    {
        [Inject] private IFacturaServicio facturaServicio { get; set; }
        [Inject] private IExamenServicio ExamenServicio { get; set; }
        [Inject] private IUsuarioServicio usuarioServicio { get; set; }
        [Inject] private IDetalleFacturaServicio detalleFacturaServicio { get; set; }
        [Inject] private IMedicamentoServicio medicamentoServicio { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }
        [Inject] NavigationManager _navigationManager { get; set; }
        [Inject] private IHttpContextAccessor httpContextAccessor { get; set; }
        [Inject] private IEstablecimientoServicio establecimientoServicio { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }
        [Inject] private IClienteServicio clienteServicio { get; set; }

        private Establecimiento establecimiento = new Establecimiento();
        private Cliente cliente = new Cliente();
        public Modelos.Factura factura = new Modelos.Factura();
        private Usuario usuario = new Usuario();

        private List<DetalleFactura> listaDetalleFactura = new List<DetalleFactura>();
        private Medicamento medicamento = new Medicamento();
        private Examen examen = new Examen();

        private int cantidad { get; set; }
        private string busqueda { get; set; }
        private string codigoProducto { get; set; }

        protected override async Task OnInitializedAsync()
        {

            establecimiento = await establecimientoServicio.UnicoRegistroAsync();

        }

        protected async Task AgregarProducto(MouseEventArgs args)
        {
            if (args.Detail != 0)
            {
                int numericValue;
                bool isNumber = int.TryParse(codigoProducto, out numericValue);

                DetalleFactura detalle = new DetalleFactura();

                if (!isNumber)
                {
                    if (medicamento.Existencia >= cantidad)
                    {
                        detalle.Descripcion = medicamento.Nombre;
                        detalle.idMedicamento = medicamento.idMedicamento;
                        detalle.Precio = medicamento.Precio;
                        detalle.Cantidad = Convert.ToInt32(cantidad);
                        detalle.Total = medicamento.Precio * Convert.ToDouble(cantidad);
                        listaDetalleFactura.Add(detalle);
                        medicamento.Existencia = medicamento.Existencia - cantidad;
                        medicamentoServicio.ActualizarAsync(medicamento);

                        medicamento.Nombre = string.Empty;

                        medicamento.Existencia = 0;
                        cantidad = 0;
                        codigoProducto = "0";
                        factura.SubTotal = factura.SubTotal + detalle.Total;
                        factura.ISV = factura.SubTotal * 0.15;
                        factura.Total = factura.SubTotal + factura.ISV - factura.Descuento;
                    }
                    else
                    {
                        await Swal.FireAsync("Error", "Cantidad solicitada es superior al inventario, unicamente se cuenta con:" + medicamento.Existencia + " Unidades de este producto", SweetAlertIcon.Warning);
                    }

                }
                else
                {
                    detalle.Descripcion = "Examen tipo: " + examen.TipoExamen;
                    detalle.IdExamen = examen.IdExamen.ToString();
                    detalle.Precio = examen.Precio;
                    detalle.Cantidad = 1;
                    detalle.Total = examen.Precio * Convert.ToDouble(cantidad);

                    listaDetalleFactura.Add(detalle);
                    await ExamenServicio.CambiarEstadoDePagoAsync(examen.IdExamen);
                    examen.TipoExamen = string.Empty;
                    examen.Precio = 0;
                    cantidad = 0;
                    codigoProducto = "0";
                    factura.SubTotal = factura.SubTotal + detalle.Total;
                    factura.ISV = factura.SubTotal * 0.15;
                    factura.Total = factura.SubTotal + factura.ISV - factura.Descuento;
                }

            }
            else
            {

            }
        }
        protected async Task Guardar()
        {
            factura.RTNEstablecimiento = establecimiento.RTN;
            factura.NombreEstablecimiento = establecimiento.NombreEstablecimiento;
            factura.Fecha = DateTime.Now;
            factura.IdentidadCliente = cliente.IdentidadCliente;
            factura.NombreCliente = cliente.NombreCliente;
            ObtenerId(httpContextAccessor.HttpContext.User.Identity.Name);
            factura.IdEmpleado = usuario.IdEmpleado;
            int idFactura = await facturaServicio.Nueva(factura);

            if (idFactura != 0)
            {
                foreach (var item in listaDetalleFactura)
                {
                    item.IdFactura = idFactura;
                    await detalleFacturaServicio.Nuevo(item);
                }

                await Swal.FireAsync("Felicidades", "Factura guardada con exito", SweetAlertIcon.Success);

                navigationManager.NavigateTo("Factura", true);
            }
            else
            {
                await Swal.FireAsync("Error", "No se pudo guardar la factura", SweetAlertIcon.Error);
            }
        }
        private async void BuscarProducto()
        {
            int numericValue;
            bool isNumber = int.TryParse(codigoProducto, out numericValue);

            if (isNumber)
            {
                medicamento = new Medicamento();
                medicamento.idMedicamento = "-";
                examen = await ExamenServicio.BuscarPorIdAsync(codigoProducto);
                cantidad = 1;
            }
            else
            {
                examen = new Examen();
                examen.IdExamen = 0;
                medicamento = await medicamentoServicio.GetPorCodigoAsync(codigoProducto);
            }

            busqueda = null;
        }

        private async void Buscar()
        {
            cliente = await clienteServicio.GetPorIdentidadAsync(cliente.IdentidadCliente);

        }

        private async void ObtenerId(string Nombre)
        {
            usuario = await usuarioServicio.GetPorNombreAsync(Nombre);

        }
    }
}
