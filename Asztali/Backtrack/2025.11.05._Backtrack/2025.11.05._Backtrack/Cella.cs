using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025._11._05._Backtrack
{
    internal class Cella
    {
        public bool Ute => Jel == ' ' || Jel == 'S' || Jel == 'E';
        public char Jel { get; set; }
        public int S { get; }
        public int O { get; }
        private Queue<int> lehetosegek { get; }
        public bool vaneLehetoseg => lehetosegek.Count > 0;

        public Cella(char jel, int s, int o)
        {
            Jel = jel;
            lehetosegek = new Queue<int>();
            for (int i = 0; i < 4; i++) lehetosegek.Enqueue(i);
            S = s;
            O = o;
        }

        public int LehetosegValaszt()
        {
            return lehetosegek.Dequeue();
        }
    }
}
