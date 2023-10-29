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
                    CreateDB();
                }
            }
        }


        // Создание БД и таблиц
        public static async Task CreateDB()
        {
            try
            {
                string connection = "Server=(localdb)\\mssqllocaldb; Database=master; Trusted_Connection=true;";

                using (SqlConnection sqlConnection = new SqlConnection(connection))
                {
                    await sqlConnection.OpenAsync();

                    string sqlCreateDb = "CREATE DATABASE MudDBTest";
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = sqlCreateDb;
                    sqlCommand.Connection = sqlConnection;
                    await sqlCommand.ExecuteNonQueryAsync();
                }

                connection = "Server=(localdb)\\mssqllocaldb; Database=MudDBTest; Trusted_Connection=true;";
                using (SqlConnection sqlConnection = new SqlConnection(connection))
                {
                    await sqlConnection.OpenAsync();

                    string sqlCreateTable = "CREATE TABLE Grout ([Id] INT PRIMARY KEY IDENTITY, [Name] NVARCHAR(255) NOT NULL, [Volume] INT NOT NULL)";
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = sqlCreateTable;
                    sqlCommand.Connection = sqlConnection;
                    await sqlCommand.ExecuteNonQueryAsync();
                }

                using (SqlConnection sqlConnection = new SqlConnection(connection))
                {
                    await sqlConnection.OpenAsync();

                    string sqlCreateTable = "CREATE TABLE Structure ([Id] INT PRIMARY KEY IDENTITY, [Name] NVARCHAR(255) NOT NULL, [Quantity] DECIMAL(3,2) NOT NULL, [Id_grout] INT NOT NULL References Grout(Id))";
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = sqlCreateTable;
                    sqlCommand.Connection = sqlConnection;
                    await sqlCommand.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
