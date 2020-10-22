using System;
using System.Collections.Generic;
using System.Text;

namespace EventsWinkelStockOef
{
    public class Stockbeheer
    {
        public int TripelAantal { get; set; } = 100;
        public int DubbelAantal { get; set; } = 100;
        public int KriekAantal { get; set; } = 100;
        public int PilsAantal { get; set; } = 100;

        public event EventHandler<StockbeheerEventArgs> StockWijziging;

        protected virtual void OnStockWijziging(Bestelling b)
        {
            StockWijziging?.Invoke(this, new StockbeheerEventArgs { Bestelling = b });
        }

        public void OnWinkelVerkoop(object source, WinkelEventArgs args)
        {
            OnStockWijziging(args.Bestelling);
            VulStockAan(args.Bestelling);
            ToonStock();
        }

        public void ToonStock()
        {
            Console.WriteLine("----------");
            Console.WriteLine($"[stock:{ProductType.Dubbel}, {DubbelAantal}]");
            Console.WriteLine($"[stock:{ProductType.Kriek}, {KriekAantal}]");
            Console.WriteLine($"[stock:{ProductType.Pils}, {PilsAantal}]");
            Console.WriteLine($"[stock:{ProductType.Tripel}, {TripelAantal}]");
            Console.WriteLine("----------");
        }

        public void VulStockAan(Bestelling bestelling)
        {
            int minimumGrens = 25;
            switch (bestelling.Product)
            {
                case ProductType.Dubbel:
                    DubbelAantal -= bestelling.Aantal;
                    if (DubbelAantal <= minimumGrens)
                    {
                        DubbelAantal = 100;
                    }
                    break;
                case ProductType.Kriek:
                    KriekAantal -= bestelling.Aantal;
                    if (KriekAantal <= minimumGrens)
                    {
                        KriekAantal = 100;
                    }
                    break;
                case ProductType.Pils:
                    PilsAantal -= bestelling.Aantal;
                    if (PilsAantal <= minimumGrens)
                    {
                        PilsAantal = 100;
                    }
                    break;
                case ProductType.Tripel:
                    TripelAantal -= bestelling.Aantal;
                    if (TripelAantal <= minimumGrens)
                    {
                        TripelAantal = 100;
                    }
                    break;
            }
        }

    }
}
