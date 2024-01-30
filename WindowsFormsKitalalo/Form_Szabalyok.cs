using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsKitalalo
{
    public partial class Form_Szabalyok : Form
    {
        public Form_Szabalyok()
        {
            InitializeComponent();
        }

        private void button_Kezdes_Click(object sender, EventArgs e)
        {
            //Játék megnyitása, szabályzat bezárása
            Program.form_jatek.Show();
            this.Hide();

            //Lehetőségek beolvasása

        }
    }
}
