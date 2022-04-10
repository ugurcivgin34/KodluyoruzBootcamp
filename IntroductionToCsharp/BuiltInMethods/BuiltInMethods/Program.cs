using System;
using System.Collections.Generic;
using System.Linq;

namespace BuiltInMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bir kelime giriniz");

            string word = Console.ReadLine();

            //int index = word.IndexOf('i', 5);
            int startIndex = 0;
            Console.WriteLine("Aradığınız harf:");
            string charackter = Console.ReadLine();

            Console.Write($"{charackter} harfinin index değerleri:");

            while (word.IndexOf(charackter, startIndex) != -1)
            {
                int findingIndex = word.IndexOf(charackter, startIndex);
                Console.Write($"{findingIndex}, ");
                startIndex = findingIndex + 1;

            }

            //Console.WriteLine(index);

            //Başka bir örnek....
            List<string> emails = new List<string>()
            {
                "turkay.urkmez@dinamikzihin.com",
                "kirikkalp72@yahoo.com",
                "nur.bilge@microsoft.com",
                "turkay.urkmez@gmail.com",
                "babyboy@mynet.com",
                "testmail"

            };

            List<string> publicDomains = new List<string>()
            {
                "yahoo.com",
                "gmail.com",
                "mynet.com"
            };

            List<string> companyEmails = new List<string>();

            foreach (var mail in emails)
            {
                //foreach (var domain in publicDomains)
                //{
                //    if (!mail.EndsWith(domain))
                //    {

                //    }
                //}
                string[] mailParts = mail.Split('@');

                if (mailParts.Length > 1)
                {
                    string mailDomain = mailParts[1];
                    bool isExists = publicDomains.Contains(mailDomain);
                    if (!isExists)
                    {
                        companyEmails.Add(mail);
                    }
                }


            }
            Console.WriteLine("Şirket e-posta adresleri:");
            foreach (var mailAdrees in companyEmails)
            {
                Console.WriteLine(mailAdrees);
            }

            List<string> cities = new List<string>() { "Ankara", "Ankara", "Ankara", "Sinop", "İstanbul", "İstanbul", "Eskişehir", "Ankara" };
            var newCities = cities.Distinct();
            foreach (var item in newCities)
            {
                Console.WriteLine(item);
            }


            //string time = Console.ReadLine();
            //string[] tArr = time.Split(":");
            //string AmPm = tArr[2].Substring(2, 4);
            //int hh, mm, ss;
            //hh = int.Parse(tArr[0]);
            //mm = int.Parse(tArr[1]);
            //ss = int.Parse(tArr[2].Substring(0, 2));

            //string checkPM = "PM", checkAM = "AM";
            //int h = hh;
            //if (AmPm.Equals(checkAM) && hh == 12)
            //    h = 0;
            //else if (AmPm.Equals(checkPM) && hh < 12)
            //    h += 12;
            //Console.WriteLine("%02d:%02d:%02d", h, mm, ss);

        }
    }
}

        






    


