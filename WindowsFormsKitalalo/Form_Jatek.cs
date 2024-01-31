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
        private Lehetosegek kivalasztottSzo;
        private char[] megfejtettBetuk;
        private int tippekSzama = 0;

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



        //Tipp stop
        private void textBox_Tipp_TextChanged(object sender, EventArgs e)
        {
            TippStop();
        }
        private void TippStop()
        {
            if (textBox_Tipp.Text.ToLower() == "stop")
            {
                textBox_Tipp.Text = "A játék véget ért!";
                textBox_Tipp.ReadOnly = true;
                textBox_Tipp.Enabled = false;

                textBox_Megfejtes.Text = " - ";
                textBox_Megfejtes.ReadOnly = true;
                textBox_Megfejtes.Enabled = false;

                textBox_TippekSzama.Text = " - ";
                textBox_TippekSzama.ReadOnly = true;
                textBox_TippekSzama.Enabled = false;

                button_Tippel.Enabled = false;

                KivalasztottSzoKijelolese();
            }
        }
        //Kiválasztott szó kijelölése
        private void KivalasztottSzoKijelolese()
        {
            int index = listBox_Lehetosegek.Items.IndexOf(kivalasztottSzo);
            if (index != -1)
            {
                listBox_Lehetosegek.SetSelected(index, true);
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

                kivalasztottSzo = (Lehetosegek)listBox_Lehetosegek.Items[randomIndex];
                megfejtettBetuk = new char[kivalasztottSzo.LehetsegesSzavak1.Length];

                for (int i = 0; i < megfejtettBetuk.Length; i++)
                {
                    megfejtettBetuk[i] = '_';
                }

                //textBox_Tipp.Text = kivalasztottSzo.ToString();   ||Teszt céljából||
            }
        }



        //
        private void button_Tippel_Click(object sender, EventArgs e)
        {
            RandomSzo();

            string tipp = textBox_Tipp.Text.ToLower();

            if (tipp.Length != kivalasztottSzo.LehetsegesSzavak1.Length)
            {
                MessageBox.Show($"A tippnek pontosan {kivalasztottSzo.LehetsegesSzavak1.Length} karakterből kell állnia!");
                return;
            }

            string eredmeny = kivalasztottSzo.KitalalasEredmeny(tipp);
            for (int i = 0; i < kivalasztottSzo.LehetsegesSzavak1.Length; i++)
            {
                if (eredmeny[i] != '_')
                {
                    megfejtettBetuk[i] = eredmeny[i];
                }
            }

            tippekSzama++;
            textBox_Megfejtes.Text = new string(megfejtettBetuk);
            textBox_TippekSzama.Text = tippekSzama.ToString();

            if (kivalasztottSzo.Megfejtve(new string(megfejtettBetuk)))
            {
                MessageBox.Show("Gratulálok, megfejtetted!");
                // Itt még további teendőket is végezhetsz, például új játék indítása stb.
            }
        }

    }
}
