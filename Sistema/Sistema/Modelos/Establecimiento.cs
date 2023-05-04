using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public class Establecimiento
    {
        [Required(ErrorMessage = "Informacion requerida")]
        public string RTN { get; set; }
        [Required(ErrorMessage = "Informacion requerida")]
        public string IdEmpleadoJefe { get; set; }
        [Required(ErrorMessage = "Informacion requerida")]
        public string NombreJefe { get; set; }
        [Required(ErrorMessage = "Informacion requerida")]
        public string NombreEstablecimiento { get; set; }
        [Required(ErrorMessage = "Informacion requerida")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Informacion requerida")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Informacion requerida")]
        public string Telefono { get; set; }

        public Establecimiento()
        {
        }

        public Establecimiento(string rTN, string idEmpleadoJefe, string nombreJefe, string nombreEstablecimiento, string direccion, string correo, string telefono)
        {
            RTN = rTN;
            IdEmpleadoJefe = idEmpleadoJefe;
            NombreJefe = nombreJefe;
            NombreEstablecimiento = nombreEstablecimiento;
            Direccion = direccion;
            Correo = correo;
            Telefono = telefono;
        }
    }
}
