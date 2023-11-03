using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Grout.DataBaseRequest;

namespace Grout
{
    public partial class FormAdd : Form
    {
        public FormAdd()
        {
            InitializeComponent();
        }
        private void FormAdd_Load(object sender, EventArgs e)
        {
            if (tabControlIndex == 0) { tabControl.SelectTab(0); }
            else { tabControl.SelectTab(1); tabControlIndex = 0; }
        }

        public static int tabControlIndex = 0;
        public static int IdGrout = 0;

        // Сохранение нового раствора
        private void btnSaveGrout_Click(object sender, EventArgs e)
        {
            if (nameGrout.Text == "" || valueGrout.Text == "") return;

            var parameters = new Dictionary<string, object>()
            {
                {"Name", nameGrout.Text.ToString()},
                {"Value", valueGrout.Text}
            };

            string queryString = "INSERT INTO Grout (Name, Value) VALUES (@Name, @Value);";
            AddData(queryString, parameters);

            this.Close();
        }

        // Сохранение нового элемента состава
        private void btnSaveStructure_Click(object sender, EventArgs e)
        {
            if (nameStructure.Text == "" || valueStructure.Text == "") return;

            var parameters = new Dictionary<string, object>()
            {
                {"Name", nameStructure.Text.ToString()},
                {"Value", valueStructure.Text},
                {"Id_grout", IdGrout}
            };

            string queryString = "INSERT INTO Structure (Name, Value, Id_grout) VALUES (@Name, @Value, @Id_grout);";
            AddData(queryString, parameters);

            this.Close();
        }

        // Запрет ввод текста
        private void valueGrout_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Запрет ввод текста
        private void valueStructure_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
