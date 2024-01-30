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
            
            //Random szó kiválasztása
            RandomSzo();
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


        //Tipp
        private void textBox_Tipp_TextChanged(object sender, EventArgs e)
        {
            TippStop();
        }
        private void TippStop()
        {
            if (textBox_Tipp.Text.ToLower() == "stop")
            {
                textBox_Tipp.Text = "Játék megállítva!";
                textBox_Tipp.ReadOnly = true;
                textBox_Tipp.Enabled = false;

                textBox_Megfejtes.Text = " - ";
                textBox_Megfejtes.ReadOnly = true;
                textBox_Megfejtes.Enabled = false;

                textBox_TippekSzama.Text = " - ";
                textBox_TippekSzama.ReadOnly = true;
                textBox_TippekSzama.Enabled = false;
            }
        }


        //Kilépés gomb
        private void button_Kilepes_Click(object sender, EventArgs e)
        {
            Kilepes();
        }
        private void Kilepes()
        {
            this.Close();
        }


        //Random szó kiválasztása
        private void RandomSzo()
        {
            if (listBox_Lehetosegek.Items.Count > 0)
            {
                Random r = new Random();
                int randomIndex = r.Next(listBox_Lehetosegek.Items.Count);

                Lehetosegek kivalasztottSzo = (Lehetosegek)listBox_Lehetosegek.Items[randomIndex];
                //textBox_Tipp.Text = kivalasztottSzo.ToString();   ||Teszt céljából||
            }
            
        }


        //
    }
}
