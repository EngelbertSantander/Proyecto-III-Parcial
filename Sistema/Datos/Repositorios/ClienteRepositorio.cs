using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;

namespace Datos.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private string CadenaConexion;

        public ClienteRepositorio(string cadenaConexion)
        {
            CadenaConexion = cadenaConexion;
        }

        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexion);
        }

        public async Task<bool> ActualizarAsync(Cliente cliente)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"UPDATE clientes SET RTNCliente = @RTNCliente, NombreCliente = @NombreCliente, Telefono = @Telefono, Correo = @Correo, Direccion = @Direccion  WHERE IdentidadCliente = @IdentidadCliente;";
                resultado = Convert.ToBoolean(await _conexion.ExecuteAsync(sql, cliente));
            }
            catch (Exception)
            {
            }
            return resultado;
        }

        public async Task<IEnumerable<Cliente>> GetListaAsync()
        {
            IEnumerable<Cliente> lista = new List<Cliente>();
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"SELECT * FROM clientes;";
                lista = await _conexion.QueryAsync<Cliente>(sql);
            }
            catch (Exception)
            {
            }
            return lista;
        }

        public async Task<Cliente> GetPorIdentidadAsync(string IdentidadCliente)
        {
            Cliente cliente = new Cliente();
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"SELECT * FROM clientes WHERE IdentidadCliente = @IdentidadCliente;";
                cliente = await _conexion.QueryFirstAsync<Cliente>(sql, new { IdentidadCliente });
            }
            catch (Exception)
            {
            }
            return cliente;
        }

        public async Task<Cliente> GetPorRTNAsync(string RTNCliente)
        {
            Cliente cliente = new Cliente();
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"SELECT * FROM clientes WHERE RTNCliente = @RTNCliente;";
                cliente = await _conexion.QueryFirstAsync<Cliente>(sql, new { RTNCliente });
            }
            catch (Exception)
            {
            }
            return cliente;
        }

        public async Task<bool> NuevoAsync(Cliente cliente)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = "INSERT INTO clientes (IdentidadCliente, RTNCliente, NombreCliente, Telefono, Correo, Direccion)" +
                    " VALUES ( @IdentidadCliente, @RTNCliente, @NombreCliente, @Telefono, @Correo, @Direccion ); ";
                resultado = Convert.ToBoolean(await _conexion.ExecuteAsync(sql, cliente));
            }
            catch (Exception)
            {
            }
            return resultado;
        }
    }
}
