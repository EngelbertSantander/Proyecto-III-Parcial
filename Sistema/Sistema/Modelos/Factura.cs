namespace Modelos
{
    public class Factura
    {
        public int idFactura { get; set; }
        public string RTNEstablecimiento { get; set; }
        public string NombreEstablecimiento { get; set; }
        public DateTime Fecha { get; set; }
        public string IdentidadCliente { get; set; }
        public string NombreCliente { get; set; }
        public string IdEmpleado { get; set; }
        public double ISV { get; set; }
        public double Descuento { get; set; }
        public double SubTotal { get; set; }
        public double Total { get; set; }

        public Factura()
        {
        }

        public Factura(int idFactura, string rTNEstablecimiento, string nombreEstablecimiento, DateTime fecha, string identidadCliente, string nombreCliente, string idEmpleado, double iSV, double descuento, double subTotal, double total)
        {
            this.idFactura = idFactura;
            RTNEstablecimiento = rTNEstablecimiento;
            NombreEstablecimiento = nombreEstablecimiento;
            Fecha = fecha;
            IdentidadCliente = identidadCliente;
            NombreCliente = nombreCliente;
            IdEmpleado = idEmpleado;
            ISV = iSV;
            Descuento = descuento;
            SubTotal = subTotal;
            Total = total;
        }
    }

}
