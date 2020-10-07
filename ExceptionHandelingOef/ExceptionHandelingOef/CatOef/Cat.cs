using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandelingOef
{
    public class Cat
    {
        public Cat(int age)
        {
            Age = age;
        }

        public int Age { get; set; }

        public void CatAgeVerifierer()
        {
            if(Age <= 0) { throw new CustomCatError("Leeftijd is kleiner of gelijk aan 0."); }
        }
    }
}
