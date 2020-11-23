using LINQAddress.Models;
using LINQAddress.Procedures;
using System;

namespace LINQAddress
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressesCountry addressesCountry = new AddressesCountry();
            CountryReader.InitializeAddresses(@"C:\Users\Chania\Downloads\adresInfo\adresInfo.txt", addressesCountry);

            //Console.WriteLine("Gesorteerd op provincie");
            //foreach (var addresses in addressesCountry.SortedByProvinceName())
            //{
            //    Console.WriteLine(addresses.ToString());
            //}

            //Console.WriteLine("Straat bij gekozen stad");
            //foreach (var addresses in addressesCountry.StreetNamesByCity("Herzele"))
            //{
            //    Console.WriteLine(addresses.ToString());
            //}

            //Console.WriteLine("Meest Voorkomende Straat");
            //foreach (var addresses in addressesCountry.MostCommonStreetName())
            //{
            //    Console.WriteLine(addresses.ToString());
            //}

            //Console.WriteLine("Meest Voorkomende Straat op aantal");
            //foreach (var addresses in addressesCountry.MostCommonStreetName(10))
            //{
            //    Console.WriteLine(addresses.ToString());
            //}

            //Console.WriteLine("Gemeenschappelijke straten tussen 2 steden");
            //foreach (var addresses in addressesCountry.MutualeStreetsBetween2Citys("Zottegem", "Gent"))
            //{
            //    Console.WriteLine(addresses.ToString());
            //}

            //TODO!!!!!
            //Console.WriteLine("Unieke straatnamen binne gekozen stad");
            //foreach (var addresses in addressesCountry.UniqueStreetNamesWithChosenCity("Antwerpen"))
            //{
            //    Console.WriteLine(addresses.ToString());
            //}

            //Console.WriteLine("Gemeente met hoogste aantal straatnamen");
            //Console.WriteLine(addressesCountry.CityWithTheMostStreets());

            //Console.WriteLine("Gemeente met de langste straatnaam");
            //Console.WriteLine(addressesCountry.LongestStreetName());

            //Console.WriteLine("Gemeente met de langste straatnaam als object");
            //Console.WriteLine(addressesCountry.LongestStreetNameAsObject());

            //foreach (var item in addressesCountry.UniqueStreetNames("Kinrooi"))
            //{
            //    Console.WriteLine(item.ToString());
            //}
        }
    }
}
