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

        //Проверка на существование БД
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

                    string createTableQuery = "CREATE TABLE Structure ([Id] INT PRIMARY KEY IDENTITY, [Name] NVARCHAR(255) NOT NULL, [Value] DECIMAL NOT NULL, [Id_grout] INT NOT NULL References Grout(Id)  ON DELETE CASCADE)";
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
                        ReadSingleRowGrout(dgv, reader);
                    }
                    reader.Close();
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
                    ReadSingleRowStructure(dgvSt, reader);
                }
                reader.Close();
            }
        }

        // Добавление данных
        public static void AddData(string query, Dictionary<string, object> parameters)
        {
            using (var connection = new SqlConnection(connectionMudDBTest))
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

        // Удаление данных
        public static void RemoveData(string query)
        {
            using (var connection = new SqlConnection(connectionMudDBTest))
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
