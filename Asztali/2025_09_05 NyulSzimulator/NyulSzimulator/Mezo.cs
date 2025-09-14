using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyulSzimulator
{
    internal class Mezo
    {
        public IEloleny[,] racs = new IEloleny[10,10];
        private int szuletesiEsely = 70;
        Random r = new Random();


        public Mezo()
        {
            szuletesiEsely = 70;
        }

        public Mezo(int szulesely)
        {
            szuletesiEsely = szulesely;
        }


        public void RacsFeltoltes()
        {
            for (int i = 0; i < racs.GetLength(0); i++)
            {
                for (int j = 0; j < racs.GetLength(1); j++)
                {
                    if (r.Next(100) < szuletesiEsely)
                        racs[i, j] = new Nyul(5, (Nem)r.Next(2));
                    else if (r.Next(100) < 50) // Pl. 50% eséllyel fű
                        racs[i, j] = new Fu();
                }
            }
        }

        public void Eletbeallit()
        {
                   
        }

        public void FuTerjeszkedes()
        {
            for (int i = 0; i < racs.GetLength(0); i++)
            {
                for (int j = 0; j < racs.GetLength(1); j++)
                {
                    if (racs[i, j] is Fu fu && fu.ElE)
                    {
                        fu.Kiszarad();
                        // Terjeszkedés: véletlenszerűen választunk egy szomszédos üres cellát
                        if (fu.SzaporodikE())
                        {
                            var dirs = new List<(int, int)>();
                            for (int dx = -1; dx <= 1; dx++)
                                for (int dy = -1; dy <= 1; dy++)
                                {
                                    if (dx == 0 && dy == 0) continue;
                                    int x = i + dx, y = j + dy;
                                    if (x >= 0 && y >= 0 && x < racs.GetLength(0) && y < racs.GetLength(1) && racs[x, y] == null)
                                        dirs.Add((x, y));
                                }
                            if (dirs.Count > 0)
                            {
                                var (nx, ny) = dirs[new Random().Next(dirs.Count)];
                                racs[nx, ny] = new Fu();
                            }
                        }
                    }
                }
            }
        }

        

    }
}
