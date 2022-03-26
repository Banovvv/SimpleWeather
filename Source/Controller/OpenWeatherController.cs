using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Configuration;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SimpleWeather.Source.Controller
{
    internal class WeatherController : ApiController
    {
        public WeatherController() : base()
        {

        }

        public partial class WeatherForecast
        {
            //TODO
        }

        public async Task<WeatherForecast?> GetWeatherResponse()
        {
            var baseAddress = new Uri("TODO");

            //TODO
            var form = new Dictionary<string, string>();

            var client = new HttpClient()
            {
                BaseAddress = baseAddress
            };

            HttpResponseMessage weatherResponse = await client.PostAsync(baseAddress, new FormUrlEncodedContent(form));

            var jsonContent = await weatherResponse.Content.ReadAsStringAsync();

            WeatherForecast? weatherForecast = JsonConvert.DeserializeObject<WeatherForecast>(jsonContent);

            return weatherForecast;
        }
    }
}
