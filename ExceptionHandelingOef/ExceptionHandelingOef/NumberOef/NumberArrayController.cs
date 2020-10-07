using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandelingOef
{
    public static class NumberArrayController
    {
        public static void Run()
        {
            int[] numbers = { 59, 84, 76 };

            Console.Write("De array bestaat uit: ");
            foreach (int num in numbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            Console.Write("Geef de gekozen index van de array:  ");
            try
            {
                int index = int.Parse(Console.ReadLine());
                Console.WriteLine(numbers[index - 1]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("De gekozen index bestaat niet.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Geef een geldig geheel getal in.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
