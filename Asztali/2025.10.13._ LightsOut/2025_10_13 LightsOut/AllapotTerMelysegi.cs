using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_10_13_LightsOut
{
    internal class AllapotTerMelysegi
    {
        private Allapot kezdoAllapot;
        private List<string> allapotokRajza = new List<string>();

        public AllapotTerMelysegi(bool[,] palya)
        {
            kezdoAllapot = new Allapot(palya, null);
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
            Stack<Allapot> allapotok = new Stack<Allapot>();
            allapotok.Push(kezdoAllapot);
            allapotokRajza.Add(kezdoAllapot.ToString());
            Allapot akt;
            do
            {
                akt = allapotok.Pop();
                UjAllapotok(akt, allapotok);
            } while (allapotok.Count > 0 && !akt.VegallapotE);
            return akt;
        }

        private void UjAllapotok(Allapot akt, Stack<Allapot> allapotok)
        {
            for (int i = 0; i < akt.Palya.GetLength(0); i++)
            {
                for (int j = 0; j < akt.Palya.GetLength(1); j++)
                {
                    bool[,] klon = (bool[,])akt.Palya.Clone();
                    Allapot ujAllapot = new Allapot(klon, akt);
                    ujAllapot.AllapotValtozas(i, j);
                    if (!allapotokRajza.Contains(ujAllapot.ToString()))
                    {
                        allapotok.Push(ujAllapot);
                        allapotokRajza.Add(ujAllapot.ToString());
                        
                    }
                }
            }
        }
    }
}
