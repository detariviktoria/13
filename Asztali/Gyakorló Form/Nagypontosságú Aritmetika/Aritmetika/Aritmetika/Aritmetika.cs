using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aritmetika
{
    internal class Aritmetika
    {

        private List<Szamok> szamok = new List<Szamok>();

        public string Szam1 { get; }
        public string Szam2 { get;  }

        public Aritmetika(string szam1, string szam2)
        {
            szam1 = Szam1;
            szam2 = Szam2;
        }

        //public void UjSzamok(int szam1, int szam2)
        //{
        //   if(string.IsNullOrWhiteSpace.Convert.ToString((szam1)) || )
        //}

        public void Kiegeszit(string szam1, string szam2)
        {
            if (ElsoRovidebbE(szam1, szam2))
            {
                for(int i =0; i<szam2.Length;i++)
                {
                    szam1 += "0";
                }
            }
            for (int i = 0; i < szam1.Length; i++)
            {
                szam2 += "0";
            }
        }

        public bool ElsoRovidebbE(string szam1, string szam2)
        {
            if(Convert.ToString(szam1).Length < Convert.ToString(szam2).Length)
            {
                return true;
            }
            return false;
        }

        public int Osszead(string szam1, string szam2)
        {
            return Convert.ToInt32(szam1) + Convert.ToInt32(szam2);
        }

        public int Kivon(string szam1, string szam2)
        {

        }


        public bool ElsoRovidebbE(string szam1, string szam2)
        {

        }
    }
}
