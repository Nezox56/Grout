using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Grout.DataBaseRequest;

namespace Grout
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            CheckConnection(connectionMudDBTest);
        }

        
    }
}
