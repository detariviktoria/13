using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025._10._01._Csomopont
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinarisFa binarisFa = new BinarisFa();
            binarisFa.Feltoltes();
            binarisFa.Kiiratas();
            Csomopont kivElem = binarisFa.CsomopontKivalasztRnd();
            binarisFa.ElemVisszafejtes(kivElem);


            Console.ReadKey();
        }
    }
}
