using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;

namespace Datos.Repositorios
{
    public class MedicamentoRepositorio : IMedicamentoRepositorio
    {
        private string CadenaConexion;

        public MedicamentoRepositorio(string cadenaConexion)
        {
            CadenaConexion = cadenaConexion;
        }
        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexion);
        }

        public async Task<bool> ActualizarAsync(Medicamento medicamento)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"UPDATE medicamento SET  Nombre = @Nombre, Mg = @Mg, ViaDeAdministracion = @ViaDeAdministracion, ComponenteActivo = @ComponenteActivo, Laboratorio = @Laboratorio, FechaDeCaducidad = @FechaDeCaducidad, RequierePrescripcion = @RequierePrescripcion, Imagen = @Imagen, Indicaciones = @Indicaciones, Precio = @Precio, Existencia = @Existencia
                 WHERE idMedicamento = @idMedicamento;";
                resultado = Convert.ToBoolean(await _conexion.ExecuteAsync(sql, medicamento));
            }
            catch (Exception)
            {
            }
            return resultado;
        }

        public async Task<IEnumerable<Medicamento>> GetListaAsync()
        {
            IEnumerable<Medicamento> lista = new List<Medicamento>();
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"SELECT * FROM medicamento;";
                lista = await _conexion.QueryAsync<Medicamento>(sql);
            }
            catch (Exception)
            {
            }
            return lista;
        }

        public async Task<Medicamento> GetPorCodigoAsync(string idMedicamento)
        {
            Medicamento medicamento = new Medicamento();
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"SELECT * FROM medicamento WHERE idMedicamento = @idMedicamento;";
                medicamento = await _conexion.QueryFirstAsync<Medicamento>(sql, new { idMedicamento });
            }
            catch (Exception)
            {
            }
            return medicamento;
        }

        public async Task<Medicamento> GetPorNombreAsync(string Nombre)
        {
            Medicamento medicamento = new Medicamento();
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"SELECT * FROM medicamento WHERE Nombre = @Nombre;";
                medicamento = await _conexion.QueryFirstAsync<Medicamento>(sql, new { Nombre });
            }
            catch (Exception)
            {
            }
            return medicamento;
        }

        public async Task<bool> NuevoAsync(Medicamento medicamento)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"INSERT INTO medicamento (idMedicamento, Nombre, Mg, ViaDeAdministracion, ComponenteActivo, Laboratorio, FechaDeCaducidad, RequierePrescripcion, Imagen, Indicaciones, Precio, Existencia) 
                VALUES (@idMedicamento, @Nombre, @Mg, @ViaDeAdministracion, @ComponenteActivo, @Laboratorio, @FechaDeCaducidad, @RequierePrescripcion, @Imagen, @Indicaciones, @Precio, @Existencia); ";
                resultado = Convert.ToBoolean(await _conexion.ExecuteAsync(sql, medicamento));
            }
            catch (Exception)
            {
            }
            return resultado;
        }
    }
}
