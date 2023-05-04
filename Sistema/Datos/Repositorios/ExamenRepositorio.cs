using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;

namespace Datos.Repositorios
{
    public class ExamenRepositorio : IExamenRepositorio
    {
        private string CadenaConexion;

        public ExamenRepositorio(string cadenaConexion)
        {
            CadenaConexion = cadenaConexion;
        }

        public async Task<bool> ActualizarAsync(Examen examen)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"UPDATE exameneslaboratorio SET Estado = @Estado, FechaEnvio = @FechaEnvio, FechaDevolucion = @FechaDevolucion, RecogidoPorCliente = @RecogidoPorCliente WHERE IdExamen = @IdExamen;";
                resultado = Convert.ToBoolean(await _conexion.ExecuteAsync(sql, examen));
            }
            catch (Exception)
            {
            }
            return resultado;
        }

        public async Task<Examen> BuscarPorIdAsync(string IdExamen)
        {
            Examen examen = new Examen();
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"SELECT * FROM exameneslaboratorio WHERE IdExamen = @IdExamen;";
                examen = await _conexion.QueryFirstAsync<Examen>(sql, new { IdExamen });
            }
            catch (Exception)
            {
            }
            return examen;
        }

        public async Task<bool> CambiarEstadoDePagoAsync(int IdExamen)
        {
            bool resultado = false;
            try
            {
                bool Pagado = true;
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"UPDATE exameneslaboratorio SET Pagado = @Pagado WHERE IdExamen = @IdExamen;";
                resultado = Convert.ToBoolean(await _conexion.ExecuteAsync(sql, new { IdExamen, Pagado }));
            }
            catch (Exception)
            {
            }
            return resultado;
        }

        public async Task<IEnumerable<Examen>> GetListaPorEstadoAsync(string Estado)
        {
            IEnumerable<Examen> lista = new List<Examen>();
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"SELECT * FROM exameneslaboratorio WHERE Estado = @Estado; ";
                lista = await _conexion.QueryAsync<Examen>(sql, new { Estado });
            }
            catch (Exception)
            {
            }
            return lista;
        }

        public async Task<IEnumerable<Examen>> GetListaPorEstadoYIdPersonaAsync(string Estado, string IdentidadCliente)
        {
            IEnumerable<Examen> lista = new List<Examen>();
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"SELECT * FROM exameneslaboratorio WHERE Estado = @Estado AND IdentidadCliente = @IdentidadCliente; ";
                lista = await _conexion.QueryAsync<Examen>(sql, new { Estado, IdentidadCliente });
            }
            catch (Exception)
            {
            }
            return lista;
        }

        public async Task<IEnumerable<Examen>> GetListaTipoExamenAsync()
        {
            IEnumerable<Examen> lista = new List<Examen>();
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"SELECT * FROM laboratorioPrecio;";
                lista = await _conexion.QueryAsync<Examen>(sql);
            }
            catch (Exception)
            {
            }
            return lista;
        }

        public async Task<bool> NuevaMuestraAsync(Examen examen)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"INSERT INTO exameneslaboratorio (IdentidadCliente, NumMuestra, TipoExamen, FechaTomaMuestra, Estado, Pagado, Precio) 
                VALUES (@IdentidadCliente, @NumMuestra, @TipoExamen, @FechaTomaMuestra, @Estado, @Pagado, @Precio); ";
                resultado = Convert.ToBoolean(await _conexion.ExecuteAsync(sql, examen));
            }
            catch (Exception)
            {
            }
            return resultado;
        }

        public async Task<double> TraerPrecioAsync(string TipoExamen)
        {
            double precio = 0;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"SELECT Precio FROM laboratorioprecio WHERE TipoExamen = @TipoExamen;";
                precio = Convert.ToDouble(await conexion.ExecuteScalarAsync(sql, new { TipoExamen }));
            }
            catch (Exception ex)
            {
            }
            return precio;
        }

        public async Task<int> UltimoRegistro()
        {
            int idFactura = 0;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"SELECT LAST_INSERT_ID() FROM exameneslaboratorio";
                idFactura = Convert.ToInt32(await conexion.ExecuteScalarAsync(sql));
            }
            catch (Exception ex)
            {
            }
            return idFactura;
        }

        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexion);
        }

    }
}
