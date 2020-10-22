using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventsWinkelStockOef
{
    public class GrootHandelaar
    {
        private List<Bestelling> _bestellingen;

        public GrootHandelaar()
        {
            _bestellingen = new List<Bestelling>();
        }

        public void OnStockWijziging(object source, StockbeheerEventArgs args)
        {
            _bestellingen.Add(args.Bestelling);
            ToonAlleBestellingen();
        }

        public Bestelling ToonLaatsteBestelling()
        {
            return _bestellingen.LastOrDefault();
        }

        public void ToonAlleBestellingen()
        {
            int dubbelAantal = 0;
            int kriekAantal = 0;
            int pilsAantal = 0;
            int trippelAantal = 0;
            Console.WriteLine("----------");
            foreach (Bestelling bestelling in _bestellingen)
            {
                switch (bestelling.Product)
                {
                    case ProductType.Dubbel:
                        dubbelAantal += bestelling.Aantal;
                        break;
                    case ProductType.Kriek:
                        kriekAantal += bestelling.Aantal;
                        break;
                    case ProductType.Pils:
                        pilsAantal += bestelling.Aantal;
                        break;
                    case ProductType.Tripel:
                        trippelAantal += bestelling.Aantal;
                        break;
                }
            }
            if (dubbelAantal != 0)
            {
                Console.Write("Voorraadbestelling : ");
                Console.Write(ProductType.Dubbel);
                Console.Write(", ");
                Console.WriteLine(dubbelAantal.ToString());
            }
            if (kriekAantal != 0)
            {
                Console.Write("Voorraadbestelling : ");
                Console.Write(ProductType.Kriek);
                Console.Write(", ");
                Console.WriteLine(kriekAantal.ToString());
            }
            if (pilsAantal != 0)
            {
                Console.Write("Voorraadbestelling : ");
                Console.Write(ProductType.Pils);
                Console.Write(", ");
                Console.WriteLine(pilsAantal.ToString());
            }
            if (trippelAantal != 0)
            {
                Console.Write("Voorraadbestelling : ");
                Console.Write(ProductType.Tripel);
                Console.Write(", ");
                Console.WriteLine(trippelAantal.ToString());
            }
            Console.WriteLine("----------");
        }
    }
}
