namespace _2025_10_01_FaSzerkezet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FaSzerkezet faszerkezet = new FaSzerkezet();
            faszerkezet.Feltoltes();
            //faszerkezet.KiiratasVerem();
            //faszerkezet.KiiratasSor();
            Csomopont kivElem = faszerkezet.CsomopontKivalasztRnd();
            faszerkezet.ElemVisszafejtes(kivElem);
        }
    }
}
