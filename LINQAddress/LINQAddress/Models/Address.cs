using System;
using System.Collections.Generic;
using System.Text;

namespace LINQAddress.Models
{
    public class Address
    {
        public Address(string province, string city, string street)
        {
            Province = province;
            City = city;
            Street = street;
        }

        public string Province { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

        public override string ToString()
        {
            return $"{Province}, {City}, {Street}";
        }
    }
}
