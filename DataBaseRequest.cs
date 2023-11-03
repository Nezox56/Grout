using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Grout.MainForm;

namespace Grout
{
    internal class DataBaseRequest
    {
        public const string connectionMudDBTest = "Server=(localdb)\\mssqllocaldb;Database=MudDBTest;Trusted_Connection=True;";

        //проверка на существование БД
        public static async void CheckConnection(string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch
                {
                    await CreateDB();
                }
            }
        }

        // Создание БД и таблиц
        public static async Task CreateDB()
        {
            try
            {
                string connectionString = "Server=(localdb)\\mssqllocaldb; Database=master; Trusted_Connection=true;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string createDbQuery = "CREATE DATABASE MudDBTest";
                    SqlCommand command = new SqlCommand
                    {
                        CommandText = createDbQuery,
                        Connection = connection
                    };
                    await command.ExecuteNonQueryAsync();
                }

                connectionString = "Server=(localdb)\\mssqllocaldb; Database=MudDBTest; Trusted_Connection=true;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string createTableQuery = "CREATE TABLE Grout ([Id] INT PRIMARY KEY IDENTITY, [Name] NVARCHAR(255) NOT NULL, [Value] INT NOT NULL)";
                    SqlCommand command = new SqlCommand
                    {
                        CommandText = createTableQuery,
                        Connection = connection
                    };
                    await command.ExecuteNonQueryAsync();
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string createTableQuery = "CREATE TABLE Structure ([Id] INT PRIMARY KEY IDENTITY, [Name] NVARCHAR(255) NOT NULL, [Value] DECIMAL NOT NULL, [Id_grout] INT NOT NULL References Grout(Id))";
                    SqlCommand command = new SqlCommand
                    {
                        CommandText = createTableQuery,
                        Connection = connection
                    };
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Добавление данных
        public static void AddData(string connectionString, string query, Dictionary<string, object> parameters)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection) { CommandType = CommandType.Text };

                foreach (var parameter in parameters)
                {
                    if (parameter.Key == "@Name")
                    {
                        command.Parameters.AddWithValue("@" + parameter.Key, parameter.Value.ToString());
                        continue;
                    }
                    command.Parameters.AddWithValue("@" + parameter.Key, parameter.Value);
                }

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        //Удаление данных
        public static void RemoveData(string connectionString, string query)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection) { CommandType = CommandType.Text };

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
