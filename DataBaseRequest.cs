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
        //public const string connectionMudDBTest = "Server=(localdb)\\mssqllocaldb;Database=MudDBTest;Trusted_Connection=True;";
        //public const string connectionMaster = "Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=True;";

        public const string _masterString = "master";
        public const string _mudDBTestString = "MudDBTest";

        //проверка на существование БД
        public static async Task CheckConnection(string connectionStringDB)
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
                    await CreateDB(_masterString, _mudDBTestString);
                }
            }
        }


        // Создание БД
        public static async Task CreateDB(string connectionStringDB, string nameDB)
        {
            try
            {
                string connectionString = $"Server=(localdb)\\mssqllocaldb; Database={connectionStringDB}; Trusted_Connection=true;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string createDbQuery = $"CREATE DATABASE {nameDB}";
                    SqlCommand command = new SqlCommand();
                    command.CommandText = createDbQuery;
                    command.Connection = connection;
                    await command.ExecuteNonQueryAsync();
                }
                    await CreateTable(_mudDBTestString, "CREATE TABLE Grout ([Id] INT PRIMARY KEY IDENTITY, " +
                        "[Name] NVARCHAR(255) NOT NULL, [Volume] INT NOT NULL)");
                    await CreateTable(_mudDBTestString, "CREATE TABLE Structure ([Id] INT PRIMARY KEY IDENTITY, " +
                        "[Name] NVARCHAR(255) NOT NULL, [Quantity] DECIMAL(3,2) NOT NULL, " +
                        "[Id_grout] INT NOT NULL References Grout(Id))");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Создание таблицы
        public static async Task CreateTable(string connectionStringDB, string queryTable)
        {
            try
            {
                string connectionString = $"Server=(localdb)\\mssqllocaldb; Database={connectionStringDB}; Trusted_Connection=true;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string createTableQuery = queryTable;
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