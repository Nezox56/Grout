using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Grout.MainForm;

namespace Grout
{
    internal class DataBaseRequest
    {
         public const string _masterString = "master";
        public const string _mudDBTestString = "MudDBTest";

        //проверка на существование БД
        public static async void CheckConnection(string connectionStringDB)
        {
            string connectionString = $"Server=(localdb)\\mssqllocaldb; Database={connectionStringDB}; Trusted_Connection=true;";
            using (SqlConnection connection = new SqlConnection(connectionString))
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
                    SqlCommand command = new SqlCommand();
                    command.CommandText = createDbQuery;
                    command.Connection = connection;
                    await command.ExecuteNonQueryAsync();
                }

                connectionString = "Server=(localdb)\\mssqllocaldb; Database=MudDBTest; Trusted_Connection=true;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string createTableQuery = "CREATE TABLE Grout ([Id] INT PRIMARY KEY IDENTITY, [Name] NVARCHAR(255) NOT NULL, [Volume] INT NOT NULL)";
                    SqlCommand command = new SqlCommand();
                    command.CommandText = createTableQuery;
                    command.Connection = connection;
                    await command.ExecuteNonQueryAsync();
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string createTableQuery = "CREATE TABLE Structure ([Id] INT PRIMARY KEY IDENTITY, [Name] NVARCHAR(255) NOT NULL, [Quantity] DECIMAL(3,2) NOT NULL, [Id_grout] INT NOT NULL References Grout(Id))";
                    SqlCommand command = new SqlCommand();
                    command.CommandText = createTableQuery;
                    command.Connection = connection;
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}