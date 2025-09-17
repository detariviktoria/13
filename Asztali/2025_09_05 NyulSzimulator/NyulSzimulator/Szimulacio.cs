using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyulSzimulator
{
    internal class Szimulacio
    {
        static Mezo mezo = new Mezo(10,10,20);

        public static void Run()
        {
            mezo.RacsFeltoltes();
            //((Nyul)mezo.racs[0, 0]).Nem = Nem.Him;
        }

        public static void NyulSzomszedMegjelenites()
        {
            for (int i = 0; i < mezo.racs.GetLength(0); i++)
            {
                for (int j = 0; j < mezo.racs.GetLength(1); j++)
                {
                    IEloleny cell = mezo.racs[i, j];
                    //if(cell != null && cell.GetType() == typeof(Nyul))
                    if (cell is Nyul)
                        Console.Write("" + ((Nyul)cell).NyulSzomszedok(mezo.racs, i, j).Count);
                    else
                        Console.Write("_");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void NyulMegjelenites()
        {
            for (int i = 0; i < mezo.racs.GetLength(0); i++)
            {
                for (int j = 0; j < mezo.racs.GetLength(1); j++)
                {
                    IEloleny cell = mezo.racs[i, j];
                    //if(cell != null && cell.GetType() == typeof(Nyul))
                    if (cell is Nyul)
                        Console.Write("X");
                    else
                        Console.Write("_");
                }
                Console.WriteLine();
            }
            Console.WriteLine(ElolenySzama(typeof(Nyul)));
            Console.WriteLine();
        }

        public static void Leptetes()
        {
            mezo.Leptetes();
        }

        public static int ElolenySzama(Type eloleny)
        {
            int db = 0;
            for (int i = 0; i < mezo.racs.GetLength(0); i++)
            {
                for (int j = 0; j < mezo.racs.GetLength(1); j++)
                {
                    if (mezo.racs[i, j] != null && mezo.racs[i,j].GetType() == eloleny)
                        db++;
                }
            }
            return db;
        }
    }
}
