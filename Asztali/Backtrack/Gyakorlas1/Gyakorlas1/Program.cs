using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyakorlas1
{
    internal class Program
    {
        static void Main()
        {
            var szamok = new List<int> { 1, 2, 3 };
            var kimenet = new List<List<int>>();
            var jelenlegi = new List<int>();

            GenerateCombinations(szamok, 0, jelenlegi, kimenet, 2);

            foreach (var combo in kimenet)
            {
                foreach (var item in combo)
                {
                    Console.WriteLine(" " + Convert.ToInt32(item));
                }
            }
        }

        static void GenerateCombinations(List<int> szamok, int kezdoertek, List<int> jelenlegi, List<List<int>> kimenet, int k)
        {
            if (jelenlegi.Count == k)
            {
                kimenet.Add(new List<int>(jelenlegi));
                return;
            }

            for (int i = kezdoertek; i < szamok.Count; i++)
            {
                jelenlegi.Add(szamok[i]);
                GenerateCombinations(szamok, i + 1, jelenlegi, kimenet, k);
                jelenlegi.RemoveAt(jelenlegi.Count - 1); // ⬅️ backtrack lépés
            }
        }
    }
}
