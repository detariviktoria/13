namespace NyolcKiralyno
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AllapotTer at = new AllapotTer();
            at.Megoldas().ForEach(Console.WriteLine);

        }
    }
}
