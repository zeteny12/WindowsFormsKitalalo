using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsKitalalo
{
    internal static class Program
    {
        //Elérhetőség
        public static Form_Szabalyok form_szabalyok = null;
        public static Form_Jatek form_jatek = null;

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            //
            form_szabalyok = new Form_Szabalyok();
            form_jatek = new Form_Jatek();
            
            //Indítás
            Application.Run(form_szabalyok);
        }
    }
}
