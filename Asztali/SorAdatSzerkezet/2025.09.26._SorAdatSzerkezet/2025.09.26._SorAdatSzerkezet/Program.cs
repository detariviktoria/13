using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025._09._26._SorAdatSzerkezet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SorQueueAlapok();
        }

        private static void SorQueueAlapok()
        {
            Random r = new Random();

            Queue<int> sor = new Queue<int>();

            //sor szerekezetbe felvenni elemet
            for (int i = 0; i < 10; i++)
            {
                sor.Enqueue(r.Next(100));
                
            }
            // sor elemszáma
            sor.Count();

            //kiiratas
            foreach (int elem in sor)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine();

            // sor szerkezetébőé elem kivétele
            for (int i = 0; i < sor.Count; i++)
            {
                Console.Write(sor.Dequeue() + "");

            }
            Console.WriteLine();
            
            Console.WriteLine("Sor elemszáma: " + sor.Count());
            sor.ToList();
        }
    }
}
