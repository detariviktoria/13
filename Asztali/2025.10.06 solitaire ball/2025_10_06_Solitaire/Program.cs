namespace _2025_10_06_Solitaire
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AllapotTerMelysegi at = new AllapotTerMelysegi("solitaire.txt");
            var megoldas = at.MegoldasKeresese();

            foreach (var item in megoldas)
            {
                Console.WriteLine(item.ToString());
            }

            //AllapotTer atsz = new AllapotTer("uparrow.txt");
            //var megoldassz = atsz.MegoldasKeresese();

            //foreach (var item in megoldassz)
            //{
            //    Console.WriteLine(item.ToString());
            //}

        }
    }
}
