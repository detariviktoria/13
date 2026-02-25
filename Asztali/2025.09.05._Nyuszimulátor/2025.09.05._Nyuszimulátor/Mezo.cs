using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace _2025._09._05._Nyuszimulátor
{
    internal class Mezo
    {
        public IEloleny[,] racs = new IEloleny[10, 10];
        private int szuletesiEsely = 70;
        Random r = new Random();
        public void RacsFeltoltes()
        {
            for (int i = 0; i < racs.GetLength(0); i++)
            {
                for (int j = 0; j < racs.GetLength(1); j++)
                {
                    if (r.Next(100) < szuletesiEsely)
                    {
                        // konstruktor => new Nyul(r.Next(2) == 1
                        racs[i, j] = new Nyul((Nem)r.Next(2));
                    }
                }
            }
                    
        }
    }
}
