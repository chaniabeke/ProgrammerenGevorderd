using LINQAddress.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LINQAddress.Procedures
{
    public class CountryReader
    {
        public static void InitializeAddresses(string path, AddressesCountry addressesCounty)
        {

            using (StreamReader r = new StreamReader(path))
            {
                string line;
                string province; string city; string street;
                while ((line = r.ReadLine()) != null)
                {
                    string[] ss = line.Split(',').Select(x => x.Trim()).ToArray();
                    province = ss[0];
                    city = ss[1];
                    street = ss[2];

                    Address address = new Address(province, city, street);
                    addressesCounty.Addresses.Add(address);
                }
            }
        }
    }
}
