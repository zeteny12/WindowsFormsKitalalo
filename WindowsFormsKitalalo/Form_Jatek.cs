using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsKitalalo
{
    public partial class Form_Jatek : Form
    {
        public Form_Jatek()
        {
            InitializeComponent();

            //Lehetőségek beolvasása
            LehetosegBetoltes();
        }

        //Lehetőségek beolvasása
        private void LehetosegBetoltes()
        {
            //Lista tisztítása
            listBox_Lehetosegek.Items.Clear();

            //Beolvasás
            try
            {
                using (StreamReader sr = new StreamReader("szavak.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        listBox_Lehetosegek.Items.Add(new Lehetosegek(sr.ReadLine()));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
