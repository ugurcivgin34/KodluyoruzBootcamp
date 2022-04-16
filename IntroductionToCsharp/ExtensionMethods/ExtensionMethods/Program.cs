using System;
using System.Collections.Generic;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 9;
            Console.WriteLine(x.GetSquare());
            Console.WriteLine(x.GetPower(5));

            List<DateTime> holidays = new List<DateTime>
            {
                new DateTime(2022,1,1),
                new DateTime(2022,4,23),
                new DateTime(2022,5,2),
                new DateTime(2022,5,3),
                new DateTime(2022,5,4),
                new DateTime(2022,5,19)
            };
            /*
            *Bir yıl içindeki toplam çalışılan gün sayısı
             */

            Console.WriteLine(DateTime.Now.TotalWorkDays(holidays)); //2022 yılında 260 gün hafta içi varmış

            Random random = new Random();

            Console.WriteLine(random.NextLetter());
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(random.NextWord(6));

            }

        }
    }
}
