using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public class Usuario
    {
        [Required(ErrorMessage = "El código es requerido")]
        public string IdEmpleado { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Contrasena { get; set; }
        [Required(ErrorMessage = "El correo es requerido")]
        public string Correo { get; set; }
        public DateTime FechaCreacion { get; set; }
        [Required(ErrorMessage = "El rol es requerido")]
        public string Rol { get; set; }
        public byte[]? Foto { get; set; }
        public bool EstaActivo { get; set; }
        [Required(ErrorMessage = "Informacion de contacto requerida")]
        public string Celular { get; set; }
        [Required(ErrorMessage = "Informacion de contacto requerida")]
        public string Direccion { get; set; }

        public Usuario()
        {
        }

        public Usuario(string idEmpleado, string nombre, string contrasena, string correo, DateTime fechaCreacion, string rol, byte[]? foto, bool estaActivo, string celular, string direccion)
        {
            IdEmpleado = idEmpleado;
            Nombre = nombre;
            Contrasena = contrasena;
            Correo = correo;
            FechaCreacion = fechaCreacion;
            Rol = rol;
            Foto = foto;
            EstaActivo = estaActivo;
            Celular = celular;
            Direccion = direccion;
        }
    }
}
