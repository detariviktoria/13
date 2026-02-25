namespace _2025_10_13_LightsOut
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //AllapotTer szelessegi = new AllapotTer();

            
            bool[,] p = new bool[,] {
                {  true, true, false, false },
                {  true, true, true, false },
                {  true, true, true, true },
                {  true, true, true, true },
            };
            AllapotTer at = new AllapotTer(PalyaGeneralas());
            at.Megoldas().ForEach(c => Console.WriteLine(c));
            //AllapotTerMelysegi atm = new AllapotTerMelysegi(PalyaGeneralas());
            //atm.Megoldas().ForEach(c => Console.WriteLine(c));

        }

        static bool[,] PalyaGeneralas()
        {
            Random r = new Random();
            bool[,] matrix = new bool[4,4];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = r.Next(2)==0;
                }
            }
            return matrix;
        }
    }
}
