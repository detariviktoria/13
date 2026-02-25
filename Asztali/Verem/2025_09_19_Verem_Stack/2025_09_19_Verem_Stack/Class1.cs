using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_09_19_Verem_Stack
{
    internal class ZarojelEllenorzo
    {
        public static bool Ellenorzes(string kifejezes)
        {
            Stack<char> verem = new Stack<char>();

            foreach (char c in kifejezes)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    verem.Push(c);
                }
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (verem.Count == 0)
                        return false;

                    char nyito = verem.Pop();

                    if (!MegfeleloPar(nyito, c))
                        return false;
                }
            }

            return verem.Count == 0;
        }

        private static bool MegfeleloPar(char nyito, char zaro)
        {
            return (nyito == '(' && zaro == ')') ||
                   (nyito == '{' && zaro == '}') ||
                   (nyito == '[' && zaro == ']');
        }
    }
}
