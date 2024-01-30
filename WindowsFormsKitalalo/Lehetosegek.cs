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
            LehetsegesSzavak = Beolvas.Replace("\"", "").Replace(",", "");
        }

        public override string ToString()
        {
            return LehetsegesSzavak;
        }
    }
}
