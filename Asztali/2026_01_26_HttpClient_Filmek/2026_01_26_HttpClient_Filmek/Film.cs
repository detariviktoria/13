using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _2026_01_26_HttpClient_Filmek
{
    internal class Film
    {
        [JsonPropertyName("Cim")]
        public string Cim { get; init; }
        [JsonPropertyName("Hossz")]
        public int Hossz { get; init; }
        [JsonPropertyName("Ertekeles")]
        public double Ertekeles { get; init; }
        /* JSON
         {
            "mezonev1":"cim",
            "mezonev2": 32
          }
         */
    }
}
