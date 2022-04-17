using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace APIClient
{
    class Program
    {
        static async Task  Main(string[] args)
        {
            
            var client = new HttpClient();
            var response =await client.GetAsync("https://swapi.dev/api/planets/1");
            if (response.IsSuccessStatusCode)
            {
            var product=await response.Content.ReadFromJsonAsync<Planets>();
                foreach (var item in product.Films)
                {
                    Console.WriteLine(item);
                }
            }

        }

        public class Planets
        {
            public string Name { get; set; }
            public string Diameter { get; set; }
            public string Rotation_Period { get; set; }
            public string Orbital_Period { get; set; }
            public string Gravity { get; set; }
            public string Population { get; set; }
            public string Climate { get; set; }
            public string Terrain { get; set; }
            public string Surface_Water { get; set; }
            public string[] Residents { get; set; }
            public string[] Films { get; set; }
            public string Url { get; set; }
            public string Created { get; set; }
            public string Edited { get; set; }




        }

    }
}
