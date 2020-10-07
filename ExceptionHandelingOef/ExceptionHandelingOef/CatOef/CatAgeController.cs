using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandelingOef
{
    public static class CatAgeController
    {
        public static void Run()
        {
            List<Cat> cats = new List<Cat>();
            Cat cat1 = new Cat(5);
            cats.Add(cat1);
            Cat cat2 = new Cat(10);
            cats.Add(cat2);
            Cat cat3 = new Cat(0);
            cats.Add(cat3);

            foreach(Cat cat in cats)
            {
                try
                {
                    cat.CatAgeVerifierer();
                }
                catch (CustomCatError e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
        }
    }
}
