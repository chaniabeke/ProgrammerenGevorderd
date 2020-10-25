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
            Stockbeheer st = new Stockbeheer();
            GrootHandelaar g = new GrootHandelaar();

            st.ToonStock();
            w.WinkelVerkoop += s.OnWinkelVerkoop;
            st.StockWijziging += g.OnStockWijziging;
            w.WinkelVerkoop += st.OnWinkelVerkoop;

            w.VerkoopProduct(new Bestelling(ProductType.Dubbel, 50, 25, "Moerbeekstraat 25 - Geraadsbergen"));
            w.VerkoopProduct(new Bestelling(ProductType.Pils, 50, 25, "Moerbeekstraat 25 - Geraadsbergen"));
            w.VerkoopProduct(new Bestelling(ProductType.Kriek, 100, 50, "Stationsstraat 10 - Zottegem"));
            w.VerkoopProduct(new Bestelling(ProductType.Pils, 10, 95, "Moerbeekstraat 25 - Geraadsbergen"));
        }
    }
}
