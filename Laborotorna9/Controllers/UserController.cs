using Laborotorna9.Mapping;
using Laborotorna9.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;

namespace Laborotorna9.Controllers
{
    public class UserController : Controller
    {
        public List<ProductModel> CreatedProduct(){
            return new List<ProductModel>(){
                new ProductModel(0, "Product1", 4500),
                new ProductModel(1, "Product2", 7000),
                new ProductModel(2, "Product3", 8000),
                new ProductModel(3, "Product4", 1000)};
        }

        public IActionResult ShowProductTable()
        {
            List<ProductModel> productModels = CreatedProduct();
            return View(productModels);
        }

        private async Task<string> ResponceURL(string url)
        {
            string responceBody = "";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    using HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    responceBody = await response.Content.ReadAsStringAsync();
                }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync(ex.ToString());
                }
            }
            return responceBody;
        }

        public async Task<IActionResult> ShowClimateInfo(string choice_city) {
            string api = "1c93173c1c9ab97442b08b9882b6a519";
            string urlCityCod = $"http://api.openweathermap.org/geo/1.0/direct?q={choice_city}&limit=1&appid={api}";

            string responceBodyCity = await ResponceURL(urlCityCod);
            GeoCodingResponse[] geoCodingResponse = JsonConvert.DeserializeObject<GeoCodingResponse[]>(responceBodyCity) ?? new GeoCodingResponse[] { };
            // await Console.Out.WriteLineAsync(responceBody);
            string urlWeather = "";
            foreach (var item in geoCodingResponse)
            {
                await Console.Out.WriteLineAsync($"{item.Name} - lat {item.Lat},lon - {item.Lon}, state - {item.State} county - {item.Country}");
                urlWeather = $"https://api.openweathermap.org/data/2.5/weather?lat={item.Lat}&units=metric&lon={item.Lon}&appid={api}";
            }

            string responceBodyWeahter = await ResponceURL(urlWeather);

            WeatherResponse weatherResponses = JsonConvert.DeserializeObject<WeatherResponse >(responceBodyWeahter) ?? new WeatherResponse();

            await Console.Out.WriteLineAsync($"{weatherResponses.Name} - temp - {weatherResponses.Main.Temp} - temp max - {weatherResponses.Main.Temp_max}" +
                    $" - item min - {weatherResponses.Main.Temp_min} - feels like - {weatherResponses.Main.Feels_like} - visibility - {weatherResponses.Visibility}");

            await Console.Out.WriteLineAsync(responceBodyWeahter);
            return View(weatherResponses);
        }
    }
}
