





namespace _2025._09._03._esloProject
{
    internal class Program
    {
        static List<Country> countries = new List<Country>();
            
        static void Main(string[] args)
        {
            
            FajlBeolvasas();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();
            Feladat7();
            Feladat8();
            Feladat9();

            Console.ReadLine();
        }

        private static void Feladat9()
        {
            Console.WriteLine("9. Feladat: Statisztika");
            var stat = countries
                .GroupBy(c => c.ConnectionYear)   
                .OrderBy(g => g.Key);             

            foreach (var g in stat)
            {
                Console.WriteLine($"\t{g.Key} - {g.Count()} ország");
            }
        }

        private static void Feladat8()
        {
            Console.WriteLine("8. Feladat: Dániával együtt a következő országok csatlakoztak az EU-hoz 1973-ban: ");
            int DaniaYear = countries.FirstOrDefault(x => x.Name == "Dánia").ConnectionYear;

            var sameYearCountries = countries
                .Where(x => x.ConnectionYear == DaniaYear && x.Name != "Dánia");
            foreach (var i in sameYearCountries)
            {
                Console.WriteLine($"\t{i.Name}");
            }
        }

        private static void Feladat7()
        {
            var result = countries
                .OrderByDescending(c => c.ConnectionYear)
                .ThenByDescending(c => c.ConnectionMonth)
                .ThenByDescending(c => c.ConnectionDay)
                .First();
            Console.WriteLine("7. Feladat: Legutoljára csatlakozott ország: "+ result.Name);
        }

        private static void Feladat6()
        {
            Console.Write("6. feladat:\n\t Adja meg a hónap nevét: ");
            string honapNev = Console.ReadLine().ToLower();
            // honapok["május"] --> 5
            var honapok = new Dictionary<string, int>()
            {
                {"január", 1},
                {"február", 2},
                {"március", 3},
                {"április", 4},
                {"május", 5},
                {"június", 6},
                {"július", 7},
                {"augusztus", 8},
                {"szeptember", 9},
                {"október", 10},
                {"november", 11},
                {"december", 12}
            };
            
            bool vane = countries.Any(x => x.ConnectionMonth == honapok[honapNev]);

            if (vane)
                Console.WriteLine("\tTörtént csatlakozás ebben a hónapban.");
            else
                Console.WriteLine("\tNem történt csatlakozás ebben a hónapban.");
        }

        private static void Feladat5()
        {
            var magyar = countries.FirstOrDefault(c => c.Name == "Magyarország");
            Console.WriteLine($"5. feladat: Magyarország csatlakozásának dátuma: {magyar.ConnectionYear}.{magyar.ConnectionMonth:D2}.{magyar.ConnectionDay:D2}");
        }

        private static void Feladat3()
        {
            var result = countries.Count(x => x.ConnectionYear < 2018);
            Console.WriteLine($"3. feladat: EU tagállamainak száma: {result}");
        }


        private static void Feladat4()
        {
            var result = countries.Count(x => x.ConnectionYear == 2007);
            Console.WriteLine($"4. feladat: 2007-ben csatlakozott országok száma: {result}");
        }

        static void FajlBeolvasas()
        {
            StreamReader f = new StreamReader("../EUcsatlakozas.txt");

            
            while (!f.EndOfStream)
            {
                countries.Add(new Country(f.ReadLine()));
            }
            f.Close();
        }

    }


    
}
