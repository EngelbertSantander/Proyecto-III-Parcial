using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;

namespace Datos.Repositorios
{
    public class EstablecimientoRepositorio : IEstablecimientoRepositorio
    {
        private string CadenaConexion;

        public EstablecimientoRepositorio(string cadenaConexion)
        {
            CadenaConexion = cadenaConexion;
        }
        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexion);
        }
        public async Task<bool> ActualizarAsync(Establecimiento establecimiento)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"UPDATE establecimiento SET IdEmpleadoJefe = @IdEmpleadoJefe, NombreJefe = @NombreJefe, NombreEstablecimiento = @NombreEstablecimiento,
                               Direccion = @Direccion, Correo = @Correo, Telefono = @Telefono WHERE RTN = @RTN;";
                resultado = Convert.ToBoolean(await _conexion.ExecuteAsync(sql, establecimiento));
            }
            catch (Exception)
            {
            }
            return resultado;
        }

        public async Task<IEnumerable<Establecimiento>> GetListaAsync()
        {
            IEnumerable<Establecimiento> lista = new List<Establecimiento>();
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"SELECT * FROM establecimiento;";
                lista = await _conexion.QueryAsync<Establecimiento>(sql);
            }
            catch (Exception)
            {
            }
            return lista;
        }
        public async Task<Establecimiento> GetPorCodigoAsync(string RTN)
        {
            Establecimiento establecimiento = new Establecimiento();
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"SELECT * FROM establecimiento WHERE RTN = @RTN;";
                establecimiento = await _conexion.QueryFirstAsync<Establecimiento>(sql, new { RTN });
            }
            catch (Exception)
            {
            }
            return establecimiento;
        }

        public async Task<Establecimiento> UnicoRegistroAsync()
        {
            Establecimiento establecimiento = new Establecimiento();
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"SELECT * FROM establecimiento ORDER BY RTN DESC LIMIT 1;";
                establecimiento = await _conexion.QueryFirstAsync<Establecimiento>(sql);
            }
            catch (Exception)
            {
            }
            return establecimiento;
        }
    }
}
