using EventsWinkelStockOef;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Winkel w = new Winkel();
            Sales s = new Sales();
            w.WinkelVerkoop += s.OnWinkelVerkoop;

            Console.WriteLine("Plaats bestellngen");
            Console.WriteLine("----------");
            w.VerkoopProduct(new Bestelling(ProductType.Dubbel, 50, 25, "Moerbeekstraat 25 - Geraadsbergen"));
            w.VerkoopProduct(new Bestelling(ProductType.Dubbel, 50, 25, "Moerbeekstraat 25 - Geraadsbergen"));
            w.VerkoopProduct(new Bestelling(ProductType.Kriek, 100, 50, "Stationsstraat 10 - Zottegem"));
            w.VerkoopProduct(new Bestelling(ProductType.Pils, 10, 5, "Moerbeekstraat 25 - Geraadsbergen"));
            Console.WriteLine("----------");

            s.ShowRapport();
        }
    }
}
