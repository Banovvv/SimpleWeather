using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Web.Http;

namespace SimpleWeather.Source.Controller
{
    internal partial class WeatherController : ApiController
    {
        public static string _baseUrl = $"https://api.openweathermap.org/data/2.5/weather?q=";
        public new IConfiguration Configuration { get; private set; }

        public WeatherController() : base()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true)
                .Build();
        }

        public async Task<WeatherForecast?> GetWeatherResponse()
        {
            var baseAddress = new Uri(_baseUrl + "&appid=" + Configuration["openWeatherApiKey"] + "&units=metric");

            var client = new HttpClient()
            {
                BaseAddress = baseAddress
            };

            HttpResponseMessage weatherResponse = await client.GetAsync(baseAddress);

            var jsonContent = await weatherResponse.Content.ReadAsStringAsync();

            WeatherForecast? weatherForecast = JsonConvert.DeserializeObject<WeatherForecast>(jsonContent);

            return weatherForecast;
        }
    }
}
