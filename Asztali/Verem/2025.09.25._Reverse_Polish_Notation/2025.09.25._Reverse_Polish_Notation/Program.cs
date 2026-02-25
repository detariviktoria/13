using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025._09._25._Reverse_Polish_Notation
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            //string bemenet = "70 11 mul 5 div 219 add 28 26 6 sub 6 sub div mul 448 7 mul sqrt add";
            string bemenet = "514 17 160 16 div 8 5 sub sub sub 22 474 78 add 144 sqrt div add add mod 594 162 9 div div 56 7 7 mul sqrt div 4 sub sub sub 12 25 sqrt mul 286 613 3406 453 mod mod 43681 sqrt 27 8 sub div div div 45 3 mul 35 7 add 27 sub add 260 28 15 sub div 119 17 div 4 sqrt sub sub div sub div mul 7367 1473 2 mul mod 413 5 mul 33 11 div mul 26563 6901 mod 1195 459 add mod mod 109 29 17 sub 36 sqrt div mul mod 3550 2 34 add 4 div 2652 347 mod 238 add add mod add mod 372 1121 19 div 44 11 sub sub 768 3 div sqrt sub 8 15 7 sub 4 sub sub sub div 402 add add add 833 251 75 sub 4 497 add add 10 4 sub 12 8 sub sub mul 1452 add add 659 mod 181 14 add sub 4116 7 mul 3 mul sqrt 34948 1046 2422 add add sqrt sqrt div 8 sub 80 12 3 sub 8 3 sub sub div 2 div 23 add 225 2 mul 7526 1976 mod add 6 4 sub mul 1477 3 mul 3074 828 mod mod 3 mul mod sqrt sub mul add mod";
            int szamol = Ellenorzes(bemenet);
            Console.WriteLine(szamol);

            Console.ReadKey();
        }

        private static int Ellenorzes(string bemenet)
        {
            Stack<int> stack = new Stack<int>();

            string[] ertekek = bemenet.Split(' ');


            foreach (var ertek in ertekek)
            {
                // ezt googlen néztem itt => 
                //learn.microsoft.com/hu-hu/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number#call-parse-or-tryparse-methods */
                if (Int32.TryParse(ertek, out int j))
                {
                    stack.Push(j);
                }
                else
                {
                    if (ertek == "sqrt")
                    {
                        int a = stack.Pop();
                        stack.Push((int)Math.Sqrt(a));
                    }
                    else
                    {
                        int a = stack.Pop();
                        int b = stack.Pop();
                        Szamol(a, b, ertek, stack);
                    }
                }
            }
            return stack.Pop();
        }

        private static void Szamol(int a, int b, string ertek, Stack<int> stack)
        {
            if (ertek == "add")
            {
                stack.Push(a + b);
            }
            else if (ertek == "sub")
            {
                
                stack.Push(b - a);
            }
            else if (ertek == "mul")
            {
                
                stack.Push(a * b);
            }
            else if (ertek == "div")
            {
                
                stack.Push(b / a);
            }
            else if (ertek == "mod")
            {
                
                stack.Push(b % a);
            }
        }
    }
}
