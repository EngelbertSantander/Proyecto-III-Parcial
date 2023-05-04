using Dapper;

using Datos.Interfaces;
using MySql.Data.MySqlClient;

namespace Datos.Repositorios
{
    public class LaboratorioRepositorio
    {
        private string cadenaConexion;

        public LaboratorioRepositorio(string cadenaConexion)
        {
            this.cadenaConexion = cadenaConexion;
        }
        private MySqlConnection Conexion()
        {
            return new MySqlConnection(cadenaConexion);
        }
        public async Task<bool> ActualizarAsync(Laboratorio laboratorio)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"UPDATE laboratorio SET IdExamen = @IdExamen, IdentidadCliente = @IdentidadCliente, NumMuestra = @NumMuestra,
                               TipoExamen = @TipoExamen, FechaTomaMuestra = @FechaTomaMuestra  ";
                resultado = Convert.ToBoolean(await _conexion.ExecuteAsync(sql, laboratorio));
            }
            catch (Exception)
            {
            }
            return resultado;
        }

    }
}
