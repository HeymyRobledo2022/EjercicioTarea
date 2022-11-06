using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;


namespace Datos
{
    public class UsuarioDatos
    {
        public async Task<bool> LoginAsync(string correo, String contrasena)
        {
            bool valido=false;
            try
            {
                string sql = "SELECT 1 FROM usuario WHERE Correo=@Correo AND Contrasena=@Contrasena; ";

                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                   await _conexion.OpenAsync();
                    using(MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@Correo", MySqlDbType.VarChar, 50).Value = correo;
                        comando.Parameters.Add("@Contrasena", MySqlDbType.VarChar, 50).Value= contrasena;

                       valido =Convert.ToBoolean( await comando.ExecuteScalarAsync());
                    }
                }
            }
            catch(Exception ex)
            {

            }
            return valido;
        }

        public async Task<DataTable> DevolverListaAsync()
        {
            DataTable dt = new DataTable(); 
            try
            {
                string sql = "SELECT * FROM usuario";
                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        MySqlDataReader dr = (MySqlDataReader)await comando.ExecuteReaderAsync();
                        dt.Load(dr);
                    
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
          
        }

        public async Task<bool> InsertarAsync(Usuario usuario)
        {
            bool inserto = false;
            try
            {
                string sql = "INSERT INTO usuario VALUES (@Correo, @Contrasena, @Nombre); ";

                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@Correo", MySqlDbType.VarChar, 50).Value = usuario.Correo;
                        comando.Parameters.Add("@Contrasena", MySqlDbType.VarChar, 50).Value = usuario.Contrasena;
                        comando.Parameters.Add("@Nombre", MySqlDbType.VarChar, 45).Value = usuario.Nombre;

                        await comando.ExecuteNonQueryAsync();
                        inserto = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return inserto;
        }

        public async Task<bool> ActualizarAsync (Usuario usuario)
        {
            bool actualizo = false;
            try
            {
                string sql = "UPDATE usuario SET Nombre=@Nombre, Contrasena=@Contrasena WHERE Correo=@Correo; ";

                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@Correo", MySqlDbType.VarChar, 50).Value = usuario.Correo;
                        comando.Parameters.Add("@Contrasena", MySqlDbType.VarChar, 50).Value = usuario.Contrasena;
                        comando.Parameters.Add("@Nombre", MySqlDbType.VarChar, 45).Value = usuario.Nombre;

                        await comando.ExecuteNonQueryAsync();
                        actualizo = true;
                    }
                }

            }
            catch (Exception ex)
            {
            }
            return actualizo;
        }

        public async Task<bool> EliminarAsync(string correo)
        {
            bool elimino = false;
            try
            {
                string sql = "DELETE FROM usuario WHERE Correo=@Correo; ";

                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@Correo", MySqlDbType.VarChar, 50).Value = correo;
                        

                        await comando.ExecuteNonQueryAsync();
                        elimino = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return elimino;
        }
    }
}
