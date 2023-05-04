namespace Modelos
{
    public class Login
    {
        public string IdEmpleado { get; set; }
        public string Contrasena { get; set; }

        public Login()
        {
        }

        public Login(string idEmpleado, string contrasena)
        {
            IdEmpleado = idEmpleado;
            Contrasena = contrasena;
        }
    }
}
