using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public class Medicamento
    {
        [Required(ErrorMessage = "Informacion requerida")]
        public string idMedicamento { get; set; }
        [Required(ErrorMessage = "Informacion requerida")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Informacion requerida")]
        public double Mg { get; set; }
        [Required(ErrorMessage = "Informacion requerida")]
        public string ViaDeAdministracion { get; set; }
        [Required(ErrorMessage = "Informacion requerida")]
        public string ComponenteActivo { get; set; }
        [Required(ErrorMessage = "Informacion requerida")]
        public string Laboratorio { get; set; }
        [Required(ErrorMessage = "Informacion requerida")]
        public DateTime FechaDeCaducidad { get; set; }
        [Required(ErrorMessage = "Informacion requerida")]
        public bool RequierePrescripcion { get; set; }
        public byte[]? Imagen { get; set; }
        [Required(ErrorMessage = "Informacion requerida")]
        public string Indicaciones { get; set; }
        [Required(ErrorMessage = "Informacion requerida")]
        public double Precio { get; set; }
        [Required(ErrorMessage = "Informacion requerida")]
        public int Existencia { get; set; }

        public Medicamento()
        {
        }

        public Medicamento(string idMedicamento, string nombre, double mg, string viaDeAdministracion, string componenteActivo, string laboratorio, DateTime fechaDeCaducidad, bool requierePrescripcion, byte[]? imagen, string indicaciones, double precio, int existencia)
        {
            this.idMedicamento = idMedicamento;
            Nombre = nombre;
            Mg = mg;
            ViaDeAdministracion = viaDeAdministracion;
            ComponenteActivo = componenteActivo;
            Laboratorio = laboratorio;
            FechaDeCaducidad = fechaDeCaducidad;
            RequierePrescripcion = requierePrescripcion;
            Imagen = imagen;
            Indicaciones = indicaciones;
            Precio = precio;
            Existencia = existencia;
        }
    }
}
