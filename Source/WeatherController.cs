using Microsoft.Extensions.Configuration;
using System.Web.Http;

namespace SimpleWeather
{
    public class WeatherController : ApiController
    {
        private readonly string _baseUrl = $"https://api.openweathermap.org/data/2.5/";
        private new IConfiguration Configuration { get; }

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

        /// <summary>
        /// Returns an object that contains all the relevant weather forecast data for a given latitude and longitude
        /// </summary>
        /// <param name="lat">Latitude of the location</param>
        /// <param name="lon">Longitude of the location</param>
        /// <param name="units">Optional parameter, by default it is set to "metric"</param>
        /// <returns>A <see cref="WeatherForecast"/> object</returns>
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

        /// <summary>
        /// Returns an object that contains all the relevant weather forecast data for a given city
        /// </summary>
        /// <param name="cityName">The name of the city</param>
        /// <param name="units">Optional parameter, by default it is set to "metric"</param>
        /// <returns>A <see cref="WeatherForecast"/> object</returns>
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