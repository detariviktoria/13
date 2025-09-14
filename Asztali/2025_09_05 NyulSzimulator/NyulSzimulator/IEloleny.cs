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
        bool SzaporodikE(); //viselkedés, ami függ egy értéktől
    }
}
