using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_10_06_Solitaire
{
    internal class AllapotTer2
    {
        private Allapot2 KezdoAllapot { get; }

        public AllapotTer2(string utvonal)
        {
            int?[,] palya = PalyaFajlbol(utvonal);
            KezdoAllapot = new Allapot2(new int[1, 1], null);
        }

        private int?[,] PalyaFajlbol(string utvonal, int n = 7)
        {
            int?[,] palya = new int?[n, n];
            try
            {
                using (StreamReader f = new StreamReader(utvonal))
                {
                    int i = 0;
                    while (!f.EndOfStream)
                    {
                        string sor = f.ReadLine();
                        for (int j = 0; j < n; j++)
                        {
                            palya[i, j] = sor[j] == '1' ? 1 : sor[j] == '0' ? 0 : null;
                        }
                        i++;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Nem sikerült a fájlbeolvasás!");
                return null;
            }
            return palya;
        }
    }
}
