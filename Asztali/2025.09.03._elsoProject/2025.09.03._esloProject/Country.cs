using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025._09._03._esloProject
{
    internal class Country
    {
        public string Name { get; set; }
        public int ConnectionYear { get; set; }
        public int ConnectionMonth { get; set; }
        public int ConnectionDay { get; set; }

        public Country(string sor)
        {
            string[] f = sor.Split(';');
            Name = f[0];
            var parts = f[1].Split('.');

            ConnectionYear = Convert.ToInt32(parts[0]);
            ConnectionMonth = Convert.ToInt32(parts[1]);
            ConnectionDay = Convert.ToInt32(parts[2]);
        }
    }
}
