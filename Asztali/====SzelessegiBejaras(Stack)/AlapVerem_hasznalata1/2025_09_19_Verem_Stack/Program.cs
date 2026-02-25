namespace _2025_09_19_Verem_Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> verem = new Stack<int>();
            Stack<int> v2 = new Stack<int>();
            verem.Push(1);
            verem.Push(2);
            verem.Push(3);
            verem.Push(4);
            verem.Push(5);
            Console.WriteLine("Verem hossza: "+verem.Count);
            Console.WriteLine("Verem teteje: " + verem.Peek());
            while (verem.Count > 0)
            {
                v2.Push(verem.Pop());
                Console.WriteLine(v2.Peek());
            }
            for (int i = 0; i < v2.Count; i++)
            {
                verem.Push(v2.Pop());
            }
            Console.WriteLine("Verem hossza: " + verem.Count);
            //Console.WriteLine("Verem hossza: " + verem.Peek());
        }
    }
}
