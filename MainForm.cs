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
        Modified,
    }
    public partial class MainForm : Form
    {
        public MainForm()
        {
            CheckConnection(connectionMudDBTest);
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CreateCollums();
        }

        // Cобытие на выбранную ячейку в таблице Растворы
        private void dataGridViewGrout_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GetDataStructure(dataGridViewGrout, dataGridViewStructure);
        }

        // Cоздание столбцов в таблицах
        private void CreateCollums()
        {
            // Работа с колонками таблицы Растворы
            dataGridViewGrout.Columns.Add("Id", "Id");
            dataGridViewGrout.Columns.Add("Name", "Название");
            dataGridViewGrout.Columns.Add("Value", "Объем, м3");
            dataGridViewGrout.Columns.Add("IsNew", String.Empty);

            dataGridViewGrout.Columns["Id"].Visible = false;
            dataGridViewGrout.Columns["IsNew"].Visible = false;

            dataGridViewGrout.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            
            // Работа с колонками таблицы Состав
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

        // Cтрока добавления в таблицу Растворы
        public static void ReadSingleRowGrout(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2) + " м3", RowState.Existed);
        }

        // Cтрока добавления в таблицу Состав
        public static void ReadSingleRowStructure(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetDecimal(2) + " %", record.GetInt32(3), RowState.Existed);
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
            if (dataGridViewGrout.Rows.Count == 0 || dataGridViewGrout.SelectedCells.Count == 0) return;

            int rowIndex = dataGridViewGrout.CurrentCell.RowIndex;
            string idGrout = dataGridViewGrout.Rows[rowIndex].Cells["Id"].Value.ToString();
            string queryString = $"DELETE Grout WHERE (Id = {idGrout});";
            DeleteData(queryString); 
        }  

        // Добавить данные в таблицу Состав
        private void btnAddRowStructure_Click(object sender, EventArgs e)
        {
            if (dataGridViewGrout.SelectedCells.Count == 0) return;

            tabControlIndex = 1;
            IdGrout = Convert.ToInt32(dataGridViewGrout.Rows[dataGridViewGrout.CurrentCell.RowIndex].Cells[0].Value.ToString());
            
            var checkValue = CheckValueStructure(dataGridViewStructure);
            if (checkValue >= 100)
            {
                MessageBox.Show("Достигнут лимит"); 
                return;
            }

            meaningValue = checkValue;

            FormAdd formAdd = new FormAdd();
            formAdd.Show();

        }

        public static decimal CheckValueStructure(DataGridView dgv)
        {
            decimal valueSumCheck = 0;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;
                string cellValue = row.Cells[2].Value as string;
                cellValue = cellValue.Replace(" %", string.Empty);
                valueSumCheck += Convert.ToDecimal(cellValue);
            }

            return valueSumCheck;
        }

        // Удалить данные из таблицы Составы
        private void btnRemoveRowStructure_Click(object sender, EventArgs e)
        {
            if (dataGridViewStructure.Rows.Count == 0 || dataGridViewStructure.SelectedCells.Count == 0) return;

            // Получение индекса выбранной строки
            int rowIndex = dataGridViewStructure.CurrentCell.RowIndex;

            // Проверка на кол-во записей Вода
            int hasWater = 0;
            foreach (DataGridViewRow row in dataGridViewStructure.Rows)
            {
                if (row.IsNewRow) continue;
                string cellValue = row.Cells[1].Value as string; 
                if (cellValue == "Вода")
                {
                    hasWater += 1; 
                }
            }

            string valueStructure = dataGridViewStructure.Rows[rowIndex].Cells[1].Value.ToString();
            if (valueStructure == "Вода" && hasWater == 1) return;
            
            string idStructure = dataGridViewStructure.Rows[rowIndex].Cells["Id"].Value.ToString();
            string queryString = $"DELETE Structure WHERE (Id = {idStructure})";

            DeleteData(queryString);
        }
    }
}
