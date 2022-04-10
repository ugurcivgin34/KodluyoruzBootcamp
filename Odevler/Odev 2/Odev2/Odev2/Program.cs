using System;

namespace Odev2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Mart 19 da verilen ödev
            //ik kenarlarının uzunluğunu alan ve hipotenüsü hesaplayan programı yazın.

            double c;

            Console.Write("1. Kenarı Giriniz :");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("2. Kenarı Giriniz :");
            int b = Convert.ToInt32(Console.ReadLine());

            c = Math.Sqrt((a * a) + (b * b));
            Console.WriteLine("Hipotenüs : " + c);



            //a - Kullanıcı sayı girecek.UYgulama bu sayının asal olup olmadığını söyleyecek.
            Console.WriteLine("Bir sayı giriniz");
            int sayi = Convert.ToInt32(Console.ReadLine());
            int sayac = 0;

            for (int i = 2; i < sayi; i++)
            {
                if (sayi % i == 0)
                {
                    sayac++;
                }

            }

            if (sayac == 0)
            {
                Console.WriteLine(sayi + " sayi asal sayıdır");
            }
            else
            {
                Console.WriteLine(sayi + " sayi asal sayı değildir");
            }

            //--------------------------------------------------------------------------------------
            // b - Birden 10.000 bine kadar tüm asal sayıları ekrana yazan bir uygulama.

            sayac = 0;
            for (int i = 2; i < 50; i++)
            {
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        sayac++;
                    }

                }
                if (sayac == 0)
                {
                    Console.WriteLine(i);
                }
                sayac = 0;

            }
        }
    }
}
