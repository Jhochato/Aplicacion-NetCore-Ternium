using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using AppConsola_Ternium_NetCore.src.Logging;
using AppConsola_Ternium_NetCore.src.Models;

namespace AppConsola_Ternium_NetCore.src.Database
{
    public class DatabaseExecutor : IDatabaseExecutor
    {
        private readonly string connectionString;
        private readonly ILogger logger;

        public DatabaseExecutor(string connectionString, ILogger logger)
        {
            this.connectionString = connectionString;
            this.logger = logger;
        }

        public void InsertUser(User user)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("InsertarUsuario", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", user.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", user.Apellido);
                    cmd.Parameters.AddWithValue("@Edad", user.Edad);
                    cmd.Parameters.AddWithValue("@Correo", user.Correo);
                    cmd.Parameters.AddWithValue("@Hobbies", user.Hobbies);
                    cmd.Parameters.AddWithValue("@Activo", user.Activo);
                    cmd.Parameters.AddWithValue("@UsuarioCreacion", user.CreadoPor);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void GetUsersByAge(int edad)
        {
            logger.WriteSectionTitle("Resultados de usuarios de acuerdo a la edad ingresada");

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("ObtenerUsuariosPorEdad", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Edad", edad);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string logEntry = $"{DateTime.Now}: {string.Concat(reader.GetValue(1), "|", reader.GetValue(2), "|", reader.GetValue(3), "|", reader.GetValue(4), "|", reader.GetValue(5))}";
                            logger.WriteLogEntry(logEntry);
                        }
                    }
                }
            }
        }

        public void GetUsersCreatedLastTwoHours()
        {
            logger.WriteSectionTitle("Usuarios Creados en las Ultimas 2 Horas");

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("ObtUsuarioCreadosUltimas2Horas", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string logEntry = $"{DateTime.Now}: {string.Concat(reader.GetValue(1), "|", reader.GetValue(2), "|", reader.GetValue(3), "|", reader.GetValue(4), "|", reader.GetValue(5))}";
                            logger.WriteLogEntry(logEntry);
                        }
                    }
                }
            }
        }
    }
}
