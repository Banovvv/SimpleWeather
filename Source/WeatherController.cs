using Microsoft.Extensions.Configuration;

namespace SimpleWeather
{
    public class WeatherController : IDisposable
    {
        private readonly string _baseUrl = $"https://api.openweathermap.org/data/2.5/";
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public WeatherController() : base()
        {
            _httpClient = new HttpClient();

            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
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
            var baseAddress = new Uri($"{_baseUrl}weather?q={cityName}&appid={_configuration["openWeatherApiKey"]}&units={units}");

            var weatherResponse = await _httpClient.GetAsync(baseAddress);

            var jsonContent = await weatherResponse.Content.ReadAsStringAsync();

            return new CurrentWeather(jsonContent);
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
            var baseAddress = new Uri($"{_baseUrl}onecall?lat={lat}&lon={lon}&exclude=minutely&appid={_configuration["openWeatherApiKey"]}&units={units}");

            var weatherResponse = await _httpClient.GetAsync(baseAddress);

            var jsonContent = await weatherResponse.Content.ReadAsStringAsync();

            return new WeatherForecast(jsonContent);
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

            var baseAddress = new Uri($"{_baseUrl}onecall?lat={lat}&lon={lon}&exclude=minutely&appid={_configuration["openWeatherApiKey"]}&units={units}");

            var weatherResponse = await _httpClient.GetAsync(baseAddress);

            var jsonContent = await weatherResponse.Content.ReadAsStringAsync();

            return new WeatherForecast(jsonContent);
        }

        public void Dispose() => _httpClient.Dispose();
    }
}