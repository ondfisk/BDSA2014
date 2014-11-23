using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CarQueryStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseAddress = new Uri("http://www.carqueryapi.com/api/0.3");
            using (var client = new HttpClient { BaseAddress = baseAddress })
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string keyword = "Porsche Panamera";
                string fuel = "Diesel";

                var response = client.GetAsync("?cmd=getTrims&keyword=" + keyword + "&fuel_type=" + fuel).Result;

                response.EnsureSuccessStatusCode();
                
                var cars = response.Content.ReadAsAsync<CarQueryResult>().Result;

                foreach (var car in cars.Trims)
                {
                    Console.WriteLine("{0} {1} {2}", car.model_name, car.make_display, car.model_year);    
                }
            }
        }
    }
}
