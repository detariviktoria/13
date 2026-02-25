using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace _2025_11_13_BackTrakcPermutacio
{
    internal class Permutacio
    {

        public void Run()
        {
            List<int> lista = new List<int>();
            List<int> maradek = new List<int>() { 1, 2, 3,4,5 };
            BackTrack(maradek, lista);
        }

        private void BackTrack(List<int> maradek, List<int> aktlista)
        {
            if (maradek.Count == 0)
            {
                //aktlista.ForEach(c=>Console.Write(c+","));
                Console.WriteLine(string.Join(",", aktlista));

                return;
            }
            for (int i = 0; i < maradek.Count; i++)
            {
                int kivalasztott = maradek[i];
                List<int> ujMaradek = new List<int>(maradek);
                ujMaradek.RemoveAt(i);

                aktlista.Add(kivalasztott);
                BackTrack(ujMaradek, aktlista);
                aktlista.RemoveAt(aktlista.Count - 1);
            }
        }
    }
}
