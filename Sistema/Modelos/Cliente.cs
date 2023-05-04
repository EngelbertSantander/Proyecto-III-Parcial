using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public class Cliente
    {
        [Required(ErrorMessage = "Identidad es requerida")]
        public string IdentidadCliente { get; set; }
        public string RTNCliente { get; set; }
        [Required(ErrorMessage = "Nombre es requerido")]
        public string NombreCliente { get; set; }
        [Required(ErrorMessage = "Telefono es requerida")]
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
    }
}
