using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Grout.MainForm;

namespace Grout
{
    internal class DataBaseRequest
    {
        public const string connectionMudDBTest = "Server=(localdb)\\mssqllocaldb;Database=MudDBTest;Trusted_Connection=True;";

        //Проверка на существование БД
        public static async void CheckConnection(string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    connection.Close();
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

                    string createTableQuery = "CREATE TABLE Structure ([Id] INT PRIMARY KEY IDENTITY, [Name] NVARCHAR(255) NOT NULL, [Value] NUMERIC(5,2) NOT NULL, [Id_grout] INT NOT NULL References Grout(Id)  ON DELETE CASCADE)";
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



        // Получение данных Растворов
        public static void GetDataGrout(DataGridView dgv)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionMudDBTest))
                {
                    dgv.Rows.Clear();

                    string queryString = "SELECT * FROM Grout";

                    SqlCommand command = new SqlCommand(queryString, connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        AddSingleRowGrout(dgv, reader);
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Получение данных Состава
        public static void GetDataStructure(DataGridView dgvGr, DataGridView dgvSt)
        {
            using (SqlConnection connection = new SqlConnection(connectionMudDBTest))
            {
                dgvSt.Rows.Clear();

                int rowIndex = dgvGr.CurrentCell.RowIndex;
                int idGrout = Convert.ToInt32(dgvGr.Rows[rowIndex].Cells["Id"].Value.ToString());

                string queryString = $"SELECT * FROM Structure Where Id_grout={idGrout}";

                SqlCommand command = new SqlCommand(queryString, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    AddSingleRowStructure(dgvSt, reader);
                }
                reader.Close();
                connection.Close();
            }
        }



        // Запрос на добавление элемента Раствора
        public static void AddGrout(Dictionary<string, object> parameters)
        {
            string queryString = "INSERT INTO Grout (Name, Value) VALUES (@Name, @Value);";
            AddData(queryString, parameters);
        }

        // Запрос на добавление элемента Состава
        public static void AddStructure(Dictionary<string, object> parameters)
        {
            string queryString = "INSERT INTO Structure (Name, Value, Id_grout) VALUES (@Name, @Value, @Id_grout);";
            AddData(queryString, parameters);
        }

        // Добавление данных в БД
        private static void AddData(string queryString, Dictionary<string, object> parameters)
        {
            using (var connection = new SqlConnection(connectionMudDBTest))
            {
                var command = new SqlCommand(queryString, connection) { CommandType = CommandType.Text };

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



        // Запрос на удаление элемента Раствора
        public static void DeleteGrout(int idGrout)
        {
            string queryString = $"DELETE Grout WHERE (Id = {idGrout});";
            DeleteData(queryString);
        }

        // Запрос на удаление элемента Состава
        public static void DeleteStructure(int idStructure)
        {
            string queryString = $"DELETE Structure WHERE (Id = {idStructure})";
            DeleteData(queryString);
        }

        // Удаление данных в БД
        private static void DeleteData(string queryString)
        {
            using (var connection = new SqlConnection(connectionMudDBTest))
            {
                var command = new SqlCommand(queryString, connection) { CommandType = CommandType.Text };

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



        // Запрос на удаление элемента Раствора
        public static void UpdateGrout(Dictionary<string, object> parameters)
        {
            string queryString = "UPDATE Grout SET Name=@Name, Value=@Value WHERE Id=@Id";
            UpdateData(queryString, parameters);
        }

        // Запрос на удаление элемента Состава
        public static void UpdateStructure(Dictionary<string, object> parameters)
        {
            string queryString = "UPDATE Structure SET Name=@Name, Value=@Value WHERE Id=@Id";
            UpdateData(queryString, parameters);
        }

        // Обновление данных в БД
        private static void UpdateData(string queryString, Dictionary<string, object> parameters)
        {
            using (var connection = new SqlConnection(connectionMudDBTest))
            {
                var command = new SqlCommand(queryString, connection) { CommandType = CommandType.Text };

                foreach (var parameter in parameters)
                {
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

    }
}
