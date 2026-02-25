using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyolcKiralyno
{
    internal class AllapotTer
    {
        private Allapot kezdoAllapot;
        private List<string> allapotokRajza = new List<string>();

        public AllapotTer()
        {
            kezdoAllapot = new Allapot(new int[8, 8], null);
        }


        public int[,] KiralynoLerakasa(int[,] palya, int s, int o)
        {
            // int[,]ujPalya = new int[8,8];
            int[,] ujPalya = (int[,])palya.Clone();
            ujPalya[s, o] = 1;


            for (int i = 0; i < palya.GetLength(0); i++)
            {
                ujPalya[s, i] = ujPalya[s, i] == 1 ? 1 : 2;
            }

            for (int i = 0; i < palya.GetLength(1); i++)
            {
                ujPalya[i, o] = ujPalya[i, o] == 1 ? 1 : 2;

            }

            //átló
            if (s <= o)
            {

                for (int i = 0; i < s + 8 - o; i++)
                {
                    ujPalya[i, o - s + 1] = ujPalya[i, o - s + i] == 1 ? 1 : 2;
                }

            }
            else
            {
                for (int i = 0; i < o + 8 - s; i++)
                {
                    ujPalya[s - o + i, i] = ujPalya[s - o + i, i] == 1 ? 1 : 2;
                }
            }
            if (s <= o-1)
            {

                for (int i = 0; i < s + 8 - o; i++)
                {
                    ujPalya[i, o - s + 1] = ujPalya[i, o - s + i] == 1 ? 1 : 2;
                }

            }
            else
            {
                for (int i = 0; i < o + 8 - s; i++)
                {
                    ujPalya[s - o + i, i] = ujPalya[s - o + i, i] == 1 ? 1 : 2;
                }
            }
            return ujPalya;

        }

        public List<Allapot> Megoldas()
        {
            List<Allapot> megoldas = new List<Allapot>();

            Allapot akt = VegallapotKereses();
            do
            {
                megoldas.Add(akt);
                akt = akt.Szulo;
            } while (akt != null);

            return megoldas;
        }

        private Allapot VegallapotKereses()
        {

            Queue<Allapot> allapotok = new Queue<Allapot>();
            allapotok.Enqueue(kezdoAllapot);
            allapotokRajza.Add(kezdoAllapot.ToString());
            Allapot akt;
            do
            {
                akt = allapotok.Dequeue();
                UjAllapotok(akt, allapotok);

            } while (allapotok.Count > 0 && !akt.VegallapotE);
            return akt;
        }

        private void UjAllapotok(Allapot akt, Queue<Allapot> allapotok)
        {
            for (int i = 0; i < akt.Palya.GetLength(0); i++)
            {
                for(int j = 0; i<akt.Palya.GetLength(1); j++)
                {
                    int[,] ujPalya = KiralynoLerakasa(akt.Palya , i, j);
                    allapotok.Enqueue(new Allapot(ujPalya, akt));
                }
            }
        }
    }
}
