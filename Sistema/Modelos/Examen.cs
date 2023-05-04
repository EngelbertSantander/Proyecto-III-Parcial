using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public class Examen
    {
        public int IdExamen { get; set; }
        [Required(ErrorMessage = "Identidad es requerida")]
        public string IdentidadCliente { get; set; }
        [Required(ErrorMessage = "Numero de muestra es requerida")]
        public string NumMuestra { get; set; }
        [Required(ErrorMessage = "Tipo de examen es requerida")]
        public string TipoExamen { get; set; }
        public DateTime FechaTomaMuestra { get; set; }
        public string Estado { get; set; }
        public DateTime FechaEnvio { get; set; }
        public bool Pagado { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public bool RecogidoPorCliente { get; set; }
        public double Precio { get; set; }

        public Examen()
        {
        }

        public Examen(int idExamen, string identidadCliente, string numMuestra, string tipoExamen, DateTime fechaTomaMuestra, string estado, DateTime fechaEnvio, bool pagado, DateTime fechaDevolucion, bool recogidoPorCliente, double precio)
        {
            IdExamen = idExamen;
            IdentidadCliente = identidadCliente;
            NumMuestra = numMuestra;
            TipoExamen = tipoExamen;
            FechaTomaMuestra = fechaTomaMuestra;
            Estado = estado;
            FechaEnvio = fechaEnvio;
            Pagado = pagado;
            FechaDevolucion = fechaDevolucion;
            RecogidoPorCliente = recogidoPorCliente;
            Precio = precio;
        }
    }
}
