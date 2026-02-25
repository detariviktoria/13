using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorQueue_feladat_megoldas
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Ügyfelek száma: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Ügyfelek vásárlási ideje (szóközzel elválasztva):");
            string[] input = Console.ReadLine().Split();
            Queue<(int id, int ido)> sor = new Queue<(int, int)>();

            for (int i = 0; i < n; i++)
            {
                int ido = int.Parse(input[i]);
                sor.Enqueue((i + 1, ido)); // i+1 = ügyfél sorszáma
            }

            List<int> befejezesiSorrend = new List<int>();

            while (sor.Count > 0)
            {
                var (id, ido) = sor.Dequeue();
                ido -= 1; // 1 percet kiszolgálunk

                if (ido == 0)
                {
                    // Kész, hozzáadjuk a befejezési sorrendhez
                    befejezesiSorrend.Add(id);
                }
                else
                {
                    // Vissza a sor végére a maradék idővel
                    sor.Enqueue((id, ido));
                }
            }

            Console.WriteLine("Ügyfelek befejezési sorrendje:");
            for (int i = 0; i < befejezesiSorrend.Count; i++)
            {
                Console.Write($"{befejezesiSorrend[i]}");
                if (i < befejezesiSorrend.Count - 1)
                    Console.Write(", ");
            }
        }
    }
}
