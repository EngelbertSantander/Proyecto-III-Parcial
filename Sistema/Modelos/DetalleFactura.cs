namespace Modelos
{
    public class DetalleFactura
    {
        public int IdDetalle { get; set; }
        public int IdFactura { get; set; }
        public string Descripcion { get; set; }
        public string IdExamen { get; set; }
        public string idMedicamento { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public double Total { get; set; }

        public DetalleFactura()
        {
        }

    }

}
