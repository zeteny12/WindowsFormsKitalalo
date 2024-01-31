using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsKitalalo
{
    internal class Lehetosegek
    {
        string LehetsegesSzavak;

        public string LehetsegesSzavak1 { get => LehetsegesSzavak; set => LehetsegesSzavak = value; }

        public Lehetosegek(string Beolvas)
        {
            string[] szavak = Beolvas.Split(',');
            LehetsegesSzavak = szavak[0];
            LehetsegesSzavak = Beolvas.Replace("\"", "").Replace(",", "").Trim();
        }

        public override string ToString()
        {
            return LehetsegesSzavak;
        }

        public string KitalalasEredmeny(string tipp)
        {
            char[] eredmeny = new char[LehetsegesSzavak1.Length];

            for (int i = 0; i < LehetsegesSzavak1.Length; i++)
            {
                if (tipp.Contains(LehetsegesSzavak1[i]))
                {
                    eredmeny[i] = LehetsegesSzavak1[i];
                }
                else
                {
                    eredmeny[i] = '_';
                }
            }

            return new string(eredmeny);
        }

        public bool Megfejtve(string tipp)
        {
            return LehetsegesSzavak1.Equals(tipp);
        }
    }
}
