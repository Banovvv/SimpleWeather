using Microsoft.Extensions.Configuration;
using System.Web.Http;

namespace SimpleWeather
{
    public class WeatherController : ApiController
    {
        private static string _baseUrl = $"https://api.openweathermap.org/data/2.5/";
        public new IConfiguration Configuration { get; }

        public WeatherController() : base()
        {
            Configuration = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json", true)
                                    .Build();
        }

        /// <summary>
        /// Returns an object that contains all the relevant data for the current weather in a given city
        /// </summary>
        /// <param name="cityName">The name of the city</param>
        /// <param name="units">Optional parameter, by default it is set to "metric"</param>
        /// <returns>A <see cref="CurrentWeather"/> object</returns>
        public async Task<CurrentWeather> GetCurrentWeather(string cityName, string units = "metric")
        {
            var baseAddress = new Uri(_baseUrl + "weather?q=" + cityName + "&appid=" + Configuration["openWeatherApiKey"] + $"&units={units}");

            var client = new HttpClient()
            {
                BaseAddress = baseAddress
            };

            HttpResponseMessage weatherResponse = await client.GetAsync(baseAddress);

            var jsonContent = await weatherResponse.Content.ReadAsStringAsync();

            CurrentWeather currentWeather = new CurrentWeather(jsonContent);

            return currentWeather;
        }

        public async Task<WeatherForecast> GetWeatherForecast(double lat, double lon, string units = "metric")
        {
            var baseAddress = new Uri(_baseUrl + "onecall?lat=" + lat + "&lon=" + lon + "&exclude=minutely" + "&appid=" + Configuration["openWeatherApiKey"] + $"&units={units}");

            var client = new HttpClient()
            {
                BaseAddress = baseAddress
            };

            HttpResponseMessage weatherResponse = await client.GetAsync(baseAddress);

            var jsonContent = await weatherResponse.Content.ReadAsStringAsync();

            WeatherForecast weatherForecast = new WeatherForecast(jsonContent);

            return weatherForecast;
        }
        public async Task<WeatherForecast> GetWeatherForecast(string cityName, string units = "metric")
        {
            var currentCity = await GetCurrentWeather(cityName, units);
            var lat = currentCity.Coordinates.Latitude;
            var lon = currentCity.Coordinates.Longitude;

            var baseAddress = new Uri(_baseUrl + "onecall?lat=" + lat + "&lon=" + lon + "&exclude=minutely" + "&appid=" + Configuration["openWeatherApiKey"] + $"&units={units}");

            var client = new HttpClient()
            {
                BaseAddress = baseAddress
            };

            HttpResponseMessage weatherResponse = await client.GetAsync(baseAddress);

            var jsonContent = await weatherResponse.Content.ReadAsStringAsync();

            WeatherForecast weatherForecast = new WeatherForecast(jsonContent);

            return weatherForecast;
        }
    }
}