using System;
using System.Reflection.Metadata.Ecma335;

namespace NyulSzimulator
{
    internal class Program
    {
        static Mezo mezo = new Mezo();
        static void Main(string[] args)
        {
            Mezo mezo2 = new Mezo(2);
            mezo2.RacsFeltoltes();
            mezo.RacsFeltoltes();
            megjelenites();
            


            //((Nyul)mezo.racs[0, 0]).Nem = Nem.Him;
        }

        static void megjelenites()
        {
            for (int i = 0; i < mezo.racs.GetLength(0); i++)
            {
                for (int j = 0; j < mezo.racs.GetLength(1); j++)
                {
                    IEloleny cell = mezo.racs[i, j];
                    if (cell is Nyul nyul)
                    {
                        Console.Write(nyul.Nyulszomszedokszama(mezo.racs, i, j));
                    }
                    else if (cell is Fu) // vagy Fu, ha fű van
                    {
                        Console.Write("F");
                    }
                    else if (cell is Roka)
                    {
                        Console.Write("R");
                    }
                    else
                    {
                        Console.Write("_");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
