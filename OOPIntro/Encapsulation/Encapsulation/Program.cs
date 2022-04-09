using System;

namespace Encapsulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Product kolye = new Product();
            kolye.SetPrice(10);
            Console.WriteLine(kolye.GetPrice());

            kolye.Name = "Art 1";
            kolye.StockCount = 1000;



        }
    }
}
