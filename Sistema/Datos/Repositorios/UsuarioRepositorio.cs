using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;

namespace Datos.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private string CadenaConexion;

        public UsuarioRepositorio(string _cadenaConexion)
        {
            CadenaConexion = _cadenaConexion;
        }

        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexion);
        }

        public async Task<bool> ActualizarAsync(Usuario user)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"UPDATE empleados SET Nombre = @Nombre, Contrasena = @Contrasena, Correo = @Correo,
                               Rol = @Rol, Foto = @Foto, EstaActivo = @EstaActivo, Celular = @Celular, Direccion = @Direccion WHERE IdEmpleado = @IdEmpleado;";
                resultado = Convert.ToBoolean(await _conexion.ExecuteAsync(sql, user));
            }
            catch (Exception)
            {
            }
            return resultado;
        }

        public async Task<bool> EliminarAsync(string IdEmpleado)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = "DELETE FROM empleados WHERE IdEmpleado = @IdEmpleado;";
                resultado = Convert.ToBoolean(await _conexion.ExecuteAsync(sql, new { IdEmpleado }));
            }
            catch (Exception)
            {
            }
            return resultado;
        }

        public async Task<IEnumerable<Usuario>> GetListaAsync()
        {
            IEnumerable<Usuario> lista = new List<Usuario>();
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"SELECT * FROM empleados;";
                lista = await _conexion.QueryAsync<Usuario>(sql);
            }
            catch (Exception)
            {
            }
            return lista;
        }

        public async Task<Usuario> GetPorCodigoAsync(string IdEmpleado)
        {
            Usuario user = new Usuario();
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"SELECT * FROM empleados WHERE IdEmpleado = @IdEmpleado;";
                user = await _conexion.QueryFirstAsync<Usuario>(sql, new { IdEmpleado });
            }
            catch (Exception)
            {
            }
            return user;
        }

        public async Task<bool> NuevoAsync(Usuario user)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = "INSERT INTO empleados (IdEmpleado, Nombre, Contrasena, Correo, FechaCreacion, Rol, Foto, EstaActivo, Celular, Direccion)" +
                    " VALUES (@IdEmpleado, @Nombre, @Contrasena, @Correo, @FechaCreacion, @Rol, @Foto, @EstaActivo, @Celular, @Direccion); ";
                resultado = Convert.ToBoolean(await _conexion.ExecuteAsync(sql, user));
            }
            catch (Exception)
            {
            }
            return resultado;
        }

        public async Task<Usuario> GetPorNombreAsync(string Nombre)
        {
            Usuario user = new Usuario();
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"SELECT * FROM empleados WHERE Nombre = @Nombre;";
                user = await _conexion.QueryFirstAsync<Usuario>(sql, new { Nombre });
            }
            catch (Exception)
            {
            }
            return user;
        }
    }
}
