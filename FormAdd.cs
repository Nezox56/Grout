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
            if(x == 0) { tabControl.SelectTab(0); }
            else { tabControl.SelectTab(1); }
        }

        public static int x = 0;
        public static int xx = 0;


        private void btnSaveGrout_Click(object sender, EventArgs e)
        {
            var parameters = new Dictionary<string, object>()
            {
                {"Name", nameGrout.Text.ToString()},
                {"Value", valueGrout.Text}
            };
            AddData(connectionMudDBTest, "INSERT INTO Grout (Name, Value) VALUES (@Name, @Value);", parameters);

            this.Close();
        }

        private void btnSaveStructure_Click(object sender, EventArgs e)
        {
            var parameters = new Dictionary<string, object>()
            {
                {"Name", nameStructure.Text.ToString()},
                {"Value", valueStructure.Text},
                {"Id_grout", xx}
            };
            AddData(connectionMudDBTest, "INSERT INTO Structure (Name, Value, Id_grout) VALUES (@Name, @Value, @Id_grout);", parameters);

            x = 0;

            this.Close();
        }

    }
}
