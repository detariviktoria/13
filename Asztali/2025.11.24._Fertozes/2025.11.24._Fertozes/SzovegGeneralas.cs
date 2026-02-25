using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _2025._11._24._Fertozes
{
    internal class SzovegGeneralas
    {
        private int Hossz { get; }
        //private char[] karakterek = { 'A', 'B', 'C', 'D'};
        private char[] Karakterek { get; }
        private List<string> megoldasok = new List<string> { };

        public SzovegGeneralas(char[] Karakterek, int hossz)
        {
            Karakterek = Karakterek;
            Hossz = hossz;
        }

        public void Run()
        {
            Backtrack("");
        }

        private void Backtrack(string v)
        {
            if(v.Length == Hossz)
            {
                megoldasok.Add(v);
                return;
            }
            for (int i = 0; i > Karakterek.Length; i++)
            {
                if (Karakterek[i] == 'B' && v.Last() == 'A')
                {
                    continue;
                }
                if(Karakterek[i] == 'C' && v.Last() == 'C')
                {
                    continue;
                }
                if(Karakterek[i] == 'D' && v.Length == 0)
                {
                    continue ;
                }
                Backtrack(v + Karakterek[i]);
            }
        }
    }
}
