using Datos.Interfaces;
using Datos.Repositorios;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using System.Security.Claims;
namespace Blazor.Controllers
{

    public class LoginController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly Config _config;
        private ILoginRepositorio _loginRepositorio;
        private IUsuarioRepositorio _usuariosRepositorio;

        public LoginController(Config config, IWebHostEnvironment env)
        {
            _config = config;
            _loginRepositorio = new LoginRepositorio(config.CadenaConexion);
            _usuariosRepositorio = new UsuarioRepositorio(config.CadenaConexion);
            _env = env;
        }

        [HttpPost("/autenticar")]
        public async Task<IActionResult> Iniciar(Login login)
        {
            string rol = string.Empty;
            try
            {
                bool usuarioValido = await _loginRepositorio.ValidarUsuario(login);

                if (usuarioValido)
                {
                    Usuario user = await _usuariosRepositorio.GetPorCodigoAsync(login.IdEmpleado);

                    if (user.EstaActivo)
                    {

                        byte[] imageData = null;
                        imageData = user.Foto;
                        string fileName = $"miPerfil.jpg";
                        string filePath = Path.Combine(_env.WebRootPath, "css", "img", fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await stream.WriteAsync(imageData);
                        }

                        if (user.Foto == null)
                        {
                            string rutaVirtualImagen = "~/css/img/miPerfil2.jpg";
                            string rutaFisicaImagen = Path.Combine(_env.WebRootPath, rutaVirtualImagen.TrimStart('~', '/'));

                            string rutaVirtualImagen2 = "~/css/img/miPerfil.jpg";
                            string rutaFisicaImagen2 = Path.Combine(_env.WebRootPath, rutaVirtualImagen2.TrimStart('~', '/'));

                            System.IO.File.Copy(rutaFisicaImagen, rutaFisicaImagen2, true);
                        }
                        rol = user.Rol;

                        var claims = new[]
                        {
                            new Claim(ClaimTypes.Name, user.Nombre),
                            new Claim(ClaimTypes.Role, rol)
                        };

                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties { IsPersistent = true, ExpiresUtc = DateTime.UtcNow.AddMinutes(10) });
                    }
                    else
                    {
                        return LocalRedirect("/Ingreso/El usuario no esta activo");
                    }
                }
                else
                {
                    return LocalRedirect("/Ingreso/Datos incorrectos");
                }
            }
            catch (Exception)
            {
            }
            return LocalRedirect("/");
        }

        [HttpGet("/Salir")]

        public async Task<IActionResult> Cerrar()
        {
            borrar();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return LocalRedirect("/Ingreso");
        }

        public void borrar()
        {
            string fileName2 = $"miPerfil.jpg";
            string filePath2 = Path.Combine(_env.WebRootPath, "css", "img", fileName2);

            if (System.IO.File.Exists(filePath2))
            {
                System.IO.File.Delete(filePath2);
            }
        }
    }
}
