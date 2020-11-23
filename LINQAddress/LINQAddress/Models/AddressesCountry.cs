using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LINQAddress.Models
{
    public class AddressesCountry
    {
        #region Property
        public List<Address> Addresses = new List<Address>();
        #endregion


        #region Methods

        /// <summary>
        /// Geef lijst met de provincienamen, alfabetisch gesorteerd.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> SortedByProvinceName()
        {
            return Addresses.OrderBy(x => x.Province).Select(x => x.Province).Distinct();
        }

        /// <summary>
        ///  Geef lijst van straatnamen voor opgegeven gemeente.
        /// </summary>
        public IEnumerable<string> StreetNamesByCity(string city)
        {
            return Addresses.Where(x => x.City == city).Select(x => x.Street);
        }

        /// <summary>
        /// Selecteer de straatnaam die het meest keren voorkomt en druk voor elk voorkomen de provincienaam, gemeentenaam en straatnaam af.  
        /// Sortering op basis van provincie en gemeente.
        /// </summary>
        /// <returns></returns>
        public IOrderedEnumerable<Address> MostCommonStreetName()
        {
            var nameGroup = Addresses.GroupBy(x => x.Street);
            int maxCount = nameGroup.Max(x => x.Count());
            string mostCommon = nameGroup.Where(x => x.Count() == maxCount).First().Key;
            return Addresses.Where(x => x.Street == mostCommon).OrderBy(x => x.Province).ThenBy(x => x.City);
        }

        //Todo meerdere meest voorkomende op basis int nr, 
        /// <summary>
        /// Voorzie een analoge functie die de meest voorkomende straatnamen weergeeft met een parameter die aangeefthoeveel straatnamen.  
        /// Output analoog aanvoorgaande functie.
        /// </summary>
        public List<Address> MostCommonStreetName(int count)
        {
            return Addresses.GroupBy(x => x.Street).OrderByDescending(x => x.Count())
                .Take(count).SelectMany(x => x.ToList())
                .OrderBy(x => x.Street).ThenBy(x => x.Province).ThenBy(x => x.City).ToList();
        }

        /// <summary>
        /// Voorzie een functie die voor 2 opgegeven gemeenten de gemeenschappelijke lijst van straatnamen weergeeft.
        /// </summary>
        /// <param name="city1"></param>
        /// <param name="city2"></param>
        /// <returns></returns>
        public IEnumerable<string> MutualeStreetsBetween2Citys(string city1, string city2)
        {
            var list1 = Addresses.Where(x => x.City == city1).Select(x => x.Street);
            var list2 = Addresses.Where(x => x.City == city2).Select(x => x.Street);
            var list3 = list1.Intersect(list2);
            return list3;
        }

        /// <summary>
        /// Voorzie een functie die de straatnamen weergeeft die enkel voorkomen in de opgegeven gemeente,maar die niet voorkomen in een lijst vananderegemeenten
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        //TODO fixx this
        //public IEnumerable<string> UniqueStreetNamesWithChosenCity(string city)
        //{
        //    var listCity = Addresses.Where(x => x.City == city).Select(x => x.Street);
        //    var listAllStreets = Addresses.Select(x => x.Street);
        //    var listMutualeStreets = listAllStreets.Except(listCity);

        //    Console.WriteLine(listCity.Count());
        //    Console.WriteLine(listAllStreets.Count());
        //    Console.WriteLine(listMutualeStreets.Count());

        //    return listMutualeStreets;
        //}

        /// <summary>
        /// Maak een functie die de gemeente weergeeft met het hoogste aantal straatnamen.
        /// </summary>
        /// <returns></returns>
        public string CityWithTheMostStreets()
        {
            var groupby = Addresses.GroupBy(x => x.City);
            string city = groupby.OrderByDescending(x => x.Select(y => y.Street).Count()).First().Key;
            return city;
        }

        /// <summary>
        /// Geef de langste straatnaam weer.
        /// </summary>
        /// <returns></returns>
        public string LongestStreetName()
        {
            //return Addresses.GroupBy(x => x.Street.Length).First()
            return Addresses.OrderByDescending(x => x.Street.Length).Select(x => x.Street).FirstOrDefault();
        }


        /// <summary>
        /// Geef de langste straatnaam weer.
        /// </summary>
        //TODO
        public Address LongestStreetNameAsObject()
        {
            return Addresses.OrderByDescending(x => x.Street.Length).FirstOrDefault();
            //int longestLength = Addresses.OrderByDescending(x => x.Street.Length).Select(x => x.Street.Length).FirstOrDefault();
            //return Addresses.Where(x => x.Street.Length == longestLength).FirstOrDefault();
        }

        /// <summary>
        /// Geef een lijst met straatnamen die uniek zijn (en toon ook gemeente en provincie).
        /// </summary>
        public List<Address> UniqueStreetNames()
        {
            return Addresses.GroupBy(x => x.Street).Where(x => x.Count() == 1).Select(x => x.First()).ToList();
        }

        /// <summary>
        /// Geef een lijst met straatnamen die uniek zijn voor een opgegeven gemeente.
        /// </summary>
        public List<Address> UniqueStreetNames(string city)
        {
            return Addresses.GroupBy(x => x.Street).Where(x => x.Count() == 1)
                .Select(x => x.First()).Where(x => x.City == city).ToList();
        }
        #endregion
    }
}
