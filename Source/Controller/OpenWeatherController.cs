using Microsoft.Extensions.Configuration;
using System.Web.Http;

namespace SimpleWeather.Controller
{
    public class WeatherController : ApiController
    {
        public static string _baseUrl = $"https://api.openweathermap.org/data/2.5/weather?q=";
        public new IConfiguration Configuration { get; private set; }

        public WeatherController() : base()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true)
                .Build();
        }

        public async Task<CurrentWeather?> GetWeatherResponse(string cityName = "Lovech", string units = "metric")
        {
            var baseAddress = new Uri(_baseUrl + cityName + "&appid=" + Configuration["openWeatherApiKey"] + $"&units={units}");

            var client = new HttpClient()
            {
                BaseAddress = baseAddress
            };

            HttpResponseMessage weatherResponse = await client.GetAsync(baseAddress);

            var jsonContent = await weatherResponse.Content.ReadAsStringAsync();

            CurrentWeather? currentWeather = new CurrentWeather(jsonContent);

            return currentWeather;
        }
    }
}
