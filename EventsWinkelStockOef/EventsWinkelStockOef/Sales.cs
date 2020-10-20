using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventsWinkelStockOef
{
    public class Sales
    {
        private Dictionary<string, List<Bestelling>> rapport;

        public Sales()
        {
            rapport = new Dictionary<string, List<Bestelling>>();
        }

        public void OnWinkelVerkoop(object source, WinkelEventArgs args)
        {
            if (rapport.ContainsKey(args.Bestelling.Adres))
            {
                KeyValuePair<string, List<Bestelling>> keyValuePair = rapport.Where(x => x.Key == args.Bestelling.Adres).FirstOrDefault();
                keyValuePair.Value.Add(args.Bestelling);
            }
            else
            {
                List<Bestelling> nieuweBestellingen = new List<Bestelling>();
                nieuweBestellingen.Add(args.Bestelling);
                rapport.Add(args.Bestelling.Adres, nieuweBestellingen);
            }
        }

        public void ShowRapport()
        {
            Console.WriteLine("----------");
            Console.WriteLine("Sales - rapport");
            for (int indexRapport = 0; indexRapport < rapport.Count; indexRapport++)
            {
                int dubbelAantal = 0;
                int kriekAantal = 0;
                int pilsAantal = 0;
                int trippelAantal = 0;
                var rapportItem = rapport.ElementAt(indexRapport);
                Console.WriteLine(rapportItem.Key.ToString());
                for (int indexBestellingen = 0; indexBestellingen < rapportItem.Value.Count; indexBestellingen++)
                {
                    var bestellingItem = rapportItem.Value.ElementAt(indexBestellingen);
                    switch (bestellingItem.Product)
                    {
                        case ProductType.Dubbel:
                            dubbelAantal += bestellingItem.Aantal;
                            break;
                        case ProductType.Kriek:
                            kriekAantal += bestellingItem.Aantal;
                            break;
                        case ProductType.Pils:
                            pilsAantal += bestellingItem.Aantal;
                            break;
                        case ProductType.Tripel:
                            trippelAantal += bestellingItem.Aantal;
                            break;
                    }
                }
                if (dubbelAantal != 0) { 
                    Console.Write(ProductType.Dubbel);
                    Console.Write(", ");
                    Console.WriteLine(dubbelAantal.ToString()); 
                }
                if (kriekAantal != 0)
                {
                    Console.Write(ProductType.Kriek);
                    Console.Write(", ");
                    Console.WriteLine(kriekAantal.ToString());
                }
                if (pilsAantal != 0)
                {
                    Console.Write(ProductType.Pils);
                    Console.Write(", ");
                    Console.WriteLine(pilsAantal.ToString());
                }
                if (trippelAantal != 0)
                {
                    Console.Write(ProductType.Tripel);
                    Console.Write(", ");
                    Console.WriteLine(trippelAantal.ToString());
                }
            }
            Console.WriteLine("----------");
        }
    }
}
