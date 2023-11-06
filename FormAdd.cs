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

        public static int tabControlIndex = 0;
        public static int IdGrout = 0;
        public static decimal meaningValue = 0;
        public static decimal allowValue;
        public FormAdd()
        {
            InitializeComponent();
        }

        private void FormAdd_Load(object sender, EventArgs e)
        {
            if (tabControlIndex == 0) { tabControl.SelectTab(0); }
            else { tabControl.SelectTab(1); tabControlIndex = 0; }
        }

        // Сохранение нового раствора
        private void btnSaveGrout_Click(object sender, EventArgs e)
        {
            if (nameGrout.Text == "" || valueGrout.Text == "") return;

            var parameters = new Dictionary<string, object>()
            {
                {"Name", nameGrout.Text.ToString()},
                {"Value", valueGrout.Text}
            };

            AddGrout(parameters);

            this.Close();
        }

        // Сохранение нового элемента состава
        private void btnSaveStructure_Click(object sender, EventArgs e)
        {
            if (nameStructure.Text == "" || valueStructure.Text == "") return;

            if (nameStructure.Text.ToLower() != "вода" && Convert.ToDecimal(valueStructure.Text) == 100)
            {
                MessageBox.Show("100% может иметь только Вода!");
                return;
            }

            allowValue = 100 - meaningValue;

            if (Convert.ToDecimal(valueStructure.Text) > allowValue)
            {
                MessageBox.Show("Введенное значение превышает допустимое количество(%)");
                valueStructure.Text = allowValue.ToString();
                return;
            }

            var parameters = new Dictionary<string, object>()
            {
                {"Name", nameStructure.Text.ToString()},
                {"Value", Convert.ToDecimal(valueStructure.Text)},
                {"Id_grout", IdGrout}
            };

            AddStructure(parameters);

            this.Close();
        }

        // Запрет на ввод текста в поле Объем
        private void valueGrout_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Запрет на вод текста в поле Количество
        private void valueStructure_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != 44)
            {
                e.Handled = true;
            }
        }


        
    }
}
