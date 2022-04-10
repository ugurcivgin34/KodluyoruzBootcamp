using System;

namespace Odev1
{
    class Program
    {
        static void Main(string[] args)
        {
            double c;

            Console.Write("1. Kenarı Giriniz :");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("2. Kenarı Giriniz :");
            int b = Convert.ToInt32(Console.ReadLine());

            c = Math.Sqrt((a * a) + (b * b));
            Console.WriteLine("Hipotenüs : " + c);
        }
    }
}
