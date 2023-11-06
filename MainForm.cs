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

        // Проверка на лимит количества(%)
        private decimal CheckValueStructure(DataGridView dgv)
        {
            if (dgv.Rows.Count == 0) return 0;

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

        // Cтрока добавления в таблицу Растворы
        public static void AddSingleRowGrout(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2) + " м3", RowState.Existed);
        }

        // Cтрока добавления в таблицу Состав
        public static void AddSingleRowStructure(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetDecimal(2) + " %", record.GetInt32(3), RowState.Existed);
        }



        // Сохранение изменений 
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dataGridViewGrout.Rows.Count == 0 || dataGridViewGrout.SelectedCells.Count == 0) return;

            int rowIndexGrout = dataGridViewGrout.CurrentCell.RowIndex;
            string valueGroutIsNew = dataGridViewGrout.Rows[rowIndexGrout].Cells["IsNew"].Value.ToString();

            if (valueGroutIsNew.Equals(RowState.Modified.ToString()))
            {
                int id = Convert.ToInt32(dataGridViewGrout.Rows[rowIndexGrout].Cells["Id"].Value.ToString());
                string name = dataGridViewGrout.Rows[rowIndexGrout].Cells["Name"].Value.ToString();
                int value = Convert.ToInt32(dataGridViewGrout.Rows[rowIndexGrout].Cells["Value"].Value.ToString().Replace(" м3", string.Empty)); ;

                var parameters = new Dictionary<string, object>()
                {
                    {"Id", id},
                    {"Name", name},
                    {"Value", value}
                };

                UpdateGrout(parameters);
                return;
            }

            int rowIndexStructure = dataGridViewStructure.CurrentCell.RowIndex;
            string valueStructureIsNew = dataGridViewStructure.Rows[rowIndexStructure].Cells["IsNew"].Value.ToString();

            if (valueStructureIsNew.Equals(RowState.Modified.ToString()))
            {
                int id = Convert.ToInt32(dataGridViewStructure.Rows[rowIndexStructure].Cells["Id"].Value.ToString());
                string name = dataGridViewStructure.Rows[rowIndexStructure].Cells["Name"].Value.ToString();
                decimal value = Convert.ToDecimal(dataGridViewStructure.Rows[rowIndexStructure].Cells["Value"].Value.ToString().Replace(" %", string.Empty)); ;

                var parameters = new Dictionary<string, object>()
                {
                    {"Id", id},
                    {"Name", name},
                    {"Value", value}
                };

                UpdateStructure(parameters);
                return;
            }
        }

        // Обновление данных таблиц
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetDataGrout(dataGridViewGrout);
            dataGridViewGrout.ClearSelection();
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
            int idGrout = Convert.ToInt32(dataGridViewGrout.Rows[rowIndex].Cells["Id"].Value.ToString());
            DeleteGrout(idGrout); 
        }  

        // Добавить данные в таблицу Состав
        private void btnAddRowStructure_Click(object sender, EventArgs e)
        {
            if (dataGridViewGrout.SelectedCells.Count == 0) return;

            tabControlIndex = 1;
            IdGrout = Convert.ToInt32(dataGridViewGrout.Rows[dataGridViewGrout.CurrentCell.RowIndex].Cells[0].Value.ToString());
            
            decimal checkValue = CheckValueStructure(dataGridViewStructure);
            if (checkValue >= 100)
            {
                MessageBox.Show("Достигнут лимит"); 
                return;
            }

            meaningValue = checkValue;

            FormAdd formAdd = new FormAdd();
            formAdd.Show();

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
                if (cellValue.ToLower() == "вода")
                {
                    hasWater += 1; 
                }
            }

            string valueStructure = dataGridViewStructure.Rows[rowIndex].Cells[1].Value.ToString();
            if (valueStructure == "Вода" && hasWater == 1) return;
            
            int idStructure = Convert.ToInt32(dataGridViewStructure.Rows[rowIndex].Cells["Id"].Value.ToString());
            DeleteStructure(idStructure);
        }



        // Cобытие на выбранную ячейку в таблице Растворы
        private void dataGridViewGrout_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewGrout.ReadOnly = true;
            dataGridViewGrout.BeginEdit(false);

            GetDataStructure(dataGridViewGrout, dataGridViewStructure);

        }

        //Разрешение редактирования ячейки Раствора при дабл-клик
        private void dataGridViewGrout_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewGrout.IsCurrentCellDirty)
            {
                dataGridViewGrout.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            else
            {
                dataGridViewGrout.ReadOnly = false;
                dataGridViewGrout.BeginEdit(true);
            }
        }

        //Разрешение редактирования ячейки Состава при дабл-клик
        private void dataGridViewStructure_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewStructure.IsCurrentCellDirty)
            {
                dataGridViewStructure.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            else
            {
                dataGridViewStructure.ReadOnly = false;
                dataGridViewStructure.BeginEdit(true);
            }
        }

        // Cобытие на выбранную ячейку в таблице Состав
        private void dataGridViewStructure_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewStructure.ReadOnly = true;
            dataGridViewStructure.BeginEdit(false);
        }

        // Событие при изменении события ячейки Раствора
        private void dataGridViewGrout_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dataGridViewGrout.CurrentCell.RowIndex;
            dataGridViewGrout.Rows[rowIndex].Cells["IsNew"].Value = RowState.Modified;
        }

        // Событие при изменении события ячейки Состава
        private void dataGridViewStructure_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dataGridViewStructure.CurrentCell.RowIndex;
            dataGridViewStructure.Rows[rowIndex].Cells["IsNew"].Value = RowState.Modified;
        }

    }
}
