using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feladat0521
{
    internal class Termek
    {
        public string Cikkszam { get; set; }
        public string Megnevezes { get; set; }
        public int Ar { get; set; }
        public int Mennyiseg { get; set; }

        public Termek(string cikkszam, string megnevezes, int ar, int mennyiseg)
        {
            Cikkszam = cikkszam;
            Megnevezes = megnevezes;
            Ar = ar;
            Mennyiseg = mennyiseg;
        }
    }
}
