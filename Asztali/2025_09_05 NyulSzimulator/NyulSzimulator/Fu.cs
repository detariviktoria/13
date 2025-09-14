using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyulSzimulator
{
    internal class Fu : IEloleny
    {
        public bool ElE { get; private set; } = true;
        private int tapErtek = 2; // ennyi energiát ad a nyúlnak, ha megeszi
        private int kiszaradasEsely = 10; // százalék
        private int terjeszkedesEsely = 20; // százalék
        Random r = new Random();

        public Fu() { }

        public bool SzaporodikE()
        {
            // Terjeszkedik
            return r.Next(100) < terjeszkedesEsely;
        }

        public void Kiszarad()
        {
            if (r.Next(100) < kiszaradasEsely)
                ElE = false;
        }

        public int TapErtek => tapErtek;
    }
}
