using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace APIClient2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7216/api/Products");
            if (response.IsSuccessStatusCode)
            {
                var product = await response.Content.ReadFromJsonAsync<List<Product>>();
            }

        }

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal? Price { get; set; }
            public int? Stock { get; set; }
            public string? Description { get; set; }
            public double? Discount { get; set; }
            public string? ImageUrl { get; set; }



        }
    }
}
