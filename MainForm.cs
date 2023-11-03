using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static Grout.DataBaseRequest;
using static Grout.FormAdd;

namespace Grout
{
    enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CheckConnection(connectionMudDBTest);
            CreateCollums();
        }

        //событие на выбранную ячейку в таблице Растворы
        private void dataGridViewGrout_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GetDataStructure(dataGridViewGrout, dataGridViewStructure);
        }

        // создание столбцов в таблицах
        private void CreateCollums()
        {
            dataGridViewGrout.Columns.Add("Id", "Id");
            dataGridViewGrout.Columns.Add("Name", "Название");
            dataGridViewGrout.Columns.Add("Value", "Объем, м3");
            dataGridViewGrout.Columns.Add("IsNew", String.Empty);

            dataGridViewGrout.Columns["Id"].Visible = false;
            dataGridViewGrout.Columns["IsNew"].Visible = false;

            dataGridViewGrout.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            dataGridViewStructure.Columns.Add("Id", "Id");
            dataGridViewStructure.Columns.Add("Name", "Состав");
            dataGridViewStructure.Columns.Add("Value", "Количество, %");
            dataGridViewStructure.Columns.Add("Id_grout", "Id_grout");
            dataGridViewStructure.Columns.Add("IsNew", String.Empty);

            dataGridViewStructure.Columns["Id"].Visible = false;
            dataGridViewStructure.Columns["Id_grout"].Visible = false;
            dataGridViewStructure.Columns["IsNew"].Visible = false;

            dataGridViewStructure.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }


        //строка добавления в таблицу Растворы
        public static void ReadSingleRowGrout(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2) + " м3", RowState.ModifiedNew);
        }

        //строка добавления в таблицу Состав
        public static void ReadSingleRowStructure(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetDecimal(2), record.GetInt32(3), RowState.ModifiedNew);
        }



        // Обновление данных таблиц
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetDataGrout(dataGridViewGrout);
            dataGridViewStructure.Rows.Clear();
        }



        // Добавить данные в таблицу Растворы
        private void btnAddRowGrout_Click(object sender, EventArgs e)
        {
            FormAdd formAdd = new FormAdd();
            formAdd.Show();
        }

        // Удалить данные из таблицы Растворы
        private void btnRemoveRowGrout_Click(object sender, EventArgs e)
        {
            if (dataGridViewGrout.Rows.Count == 0) return;

            int rowIndex = dataGridViewGrout.CurrentCell.RowIndex;
            string idGrout = dataGridViewGrout.Rows[rowIndex].Cells["Id"].Value.ToString();
            RemoveData(connectionMudDBTest, $"DELETE Grout WHERE (Id = {idGrout});"); 
        }

        

        // Добавить данные в таблицу Состав
        private void btnAddRowStructure_Click(object sender, EventArgs e)
        {
            tabControlIndex = 1;
            IdGrout = Convert.ToInt32(dataGridViewGrout.Rows[dataGridViewGrout.CurrentCell.RowIndex].Cells[0].Value.ToString());

            FormAdd formAdd = new FormAdd();
            formAdd.Show();
        }

        // Удалить данные из таблицы Составы
        private void btnRemoveRowStructure_Click(object sender, EventArgs e)
        {
            if (dataGridViewStructure.Rows.Count == 0) return;

            int rowIndex = dataGridViewStructure.CurrentCell.RowIndex;
            string value = dataGridViewStructure.Rows[rowIndex].Cells["Id"].Value.ToString();
            RemoveData(connectionMudDBTest, $"DELETE Structure WHERE (Id = {value})");
        }
    }
}
