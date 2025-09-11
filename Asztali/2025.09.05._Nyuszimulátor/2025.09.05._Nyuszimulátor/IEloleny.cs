using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025._09._05._Nyuszimulátor
{
    internal interface IEloleny
    {
        bool ElE { get; } // állapot
        bool SzaporodikE(); // nem egy állapot (viszonyulást akarunk, ami függ egy értéktől)
    }
}
