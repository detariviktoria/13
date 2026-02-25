using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutácio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int> { 1, 2, 3 };
            var result = new List<List<int>>();

            GeneratePermutations(numbers, new List<int>(), new bool[numbers.Count], result);

            Console.WriteLine("Összes permutáció:");
            foreach (var perm in result)
            {
                string s = Convert.ToString(perm);
                if (perm.Count % 3 == 0)
                {
                    Console.Write(s + "|");
                }
                
                else
                {
                    Console.Write(s);
                }
            }
        }

        static void GeneratePermutations(List<int> nums, List<int> current, bool[] used, List<List<int>> result)
        {
            if (current.Count == nums.Count)
            {
                result.Add(new List<int>(current));
                return;
            }

            for (int i = 0; i < nums.Count; i++)
            {
                if (used[i]) continue;

                used[i] = true;
                current.Add(nums[i]);
                GeneratePermutations(nums, current, used, result);
                current.RemoveAt(current.Count - 1);
                used[i] = false;
            }

            
        }
    }
}
