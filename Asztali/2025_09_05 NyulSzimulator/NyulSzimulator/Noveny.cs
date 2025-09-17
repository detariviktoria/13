using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyulSzimulator
{
    internal abstract class Noveny : IEloleny
    {
        public bool ElE => throw new NotImplementedException();

        public List<(int, int, IEloleny)> UjEloleny => throw new NotImplementedException();

        public void Szaporodik(List<IEloleny> nyulSzomszedok, IEloleny[,] racs, int sor, int oszlop)
        {
            throw new NotImplementedException();
        }

        public bool SzaporodikE()
        {
            throw new NotImplementedException();
        }

        public void SzimulaciosLepes(IEloleny[,] racs, int sor, int oszlop)
        {
            throw new NotImplementedException();
        }

        public void MidenSzarmaztatottOsztalynak()
        {
            Console.WriteLine("siker");
        }
        public abstract void FejtsdKi();
    }
}
