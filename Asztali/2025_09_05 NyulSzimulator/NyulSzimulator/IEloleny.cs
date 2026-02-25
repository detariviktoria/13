using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyulSzimulator
{
    internal interface IEloleny
    {
        bool ElE { get; } //állapot

        void SzimulaciosLepes(IEloleny[,] racs, int sor, int oszlop);

    }
}
