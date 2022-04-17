using System;
using System.Collections.Generic;
using System.Net;

namespace Wired.com
{
    class Program
    {
       
        static void Main(string[] args)
        {
           
            var url = new Uri("https://www.wired.com/");
            var client = new WebClient();
            var html = client.DownloadString(url);
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
           
            var veri = doc.DocumentNode.SelectNodes("html/body/div[1]/div/main/div[1]/div[1]/section/div[3]/div/div/div/div/div/div/a");
            foreach (var item in veri)
            {
                Console.WriteLine(item.InnerText +" ");
                Console.WriteLine();
            }
        }
    }
}
