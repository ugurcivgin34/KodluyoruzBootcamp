using System;
using System.Collections.Generic;

namespace AynıSehirler
{
    class Program
    {
        static void Main(string[] args)
        {
            //Aynı isimli şehirlerin tekrarlanmasını engelleyip farklı listeye aktarma
            List<string> cities = new List<string>() { "Ankara", "Ankara", "Ankara", "Sinop", "İstanbul", "İstanbul", "Eskişehir", "Ankara" };
            var newCities = cities.Distinct();
            foreach (var item in newCities)
            {
                Console.WriteLine(item);
            }
        }
    }
}
