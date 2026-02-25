using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025._10._06._Solatire
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            AllapotTer ter = new AllapotTer("solitaire.txt");
            ter.KiirKezdoAllapot();

            Console.ReadKey();
        }
    }
}
