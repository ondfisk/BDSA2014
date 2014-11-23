using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Lecture11.CarQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get JSON from PostMan and go Edit->Paste Special->JSON as classes
            // Install-Package Microsoft.AspNet.WebApi.Client

            var baseAddress = new Uri("http://www.carqueryapi.com/api/0.3");
            using (var client = new HttpClient { BaseAddress = baseAddress })
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string keyword = "BMW 116 d";

                var response = client.GetAsync("?cmd=getTrims&keyword=" + keyword).Result;

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
