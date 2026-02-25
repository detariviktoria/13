using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlapVerem_hasznalata
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Stack<int> verem = new Stack<int>();

            // Elemet hozzáadunk
            verem.Push(10);
            verem.Push(20);
            verem.Push(30);

            // Megnézzük, mi van a tetején (nem vesszük le)
            Console.WriteLine("Verem teteje: " + verem.Peek());

            // Elemet levesszük
            Console.WriteLine("Levett elem: " + verem.Pop());

            // Még mi maradt a veremben
            Console.WriteLine("Verem tartalma:");
            foreach (var elem in verem)
            {
                Console.WriteLine(elem);
            }
        }
    }
}
