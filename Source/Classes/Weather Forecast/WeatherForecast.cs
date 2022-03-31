using Newtonsoft.Json.Linq;

namespace SimpleWeather
{
    /// <summary>
    /// An object that provides weather forecast data
    /// </summary>
    public class WeatherForecast
    {
        public WeatherForecast(string jsonResponse)
        {
            JObject data = JObject.Parse(jsonResponse);

            if (data != null)
            {
                Longitude = double.Parse(data.SelectToken("lon").ToString());
                Latitude = double.Parse(data.SelectToken("lat").ToString());
                Timezone = data.SelectToken("timezone").ToString();
                TimezoneOffset = int.Parse(data.SelectToken("timezone_offset").ToString()) / 3600;
                Current = new Current(data.SelectToken("current"));
                foreach (var hour in data.SelectToken("hourly"))
                {
                    Hourly.Add(new Hourly(hour));
                }
                foreach (var day in data.SelectToken("daily"))
                {
                    Daily.Add(new Daily(day));
                }
                if (data.SelectToken("alerts") != null)
                {
                    foreach(var alert in data.SelectToken("alerts"))
                    {
                        Alerts.Add(new Alerts(alert));
                    }                    
                }
            }
        }
        /// <summary>
        /// Geographical coordinates of the location (latitude)
        /// </summary>
        public double Latitude { get; }
        /// <summary>
        /// Geographical coordinates of the location (longitude)
        /// </summary>
        public double Longitude { get; }
        /// <summary>
        /// Timezone name for the requested location
        /// </summary>
        public string? Timezone { get; }
        /// <summary>
        /// Shift in hours from UTC
        /// </summary>
        public int TimezoneOffset { get; }
        /// <summary>
        /// Current weather data as an object
        /// </summary>
        public Current? Current { get; }
        /// <summary>
        /// Hourly forecast weather data as a list of objects containing the data for each hour
        /// </summary>
        public List<Hourly>? Hourly { get; } = new List<Hourly>();
        /// <summary>
        /// Daily forecast weather data as a list of objects containing the data for each day
        /// </summary>
        public List<Daily>? Daily { get; } = new List<Daily>();
        /// <summary>
        /// A list of objects containing National weather alerts data from major national weather warning systems
        /// </summary>
        public List<Alerts>? Alerts { get; } = new List<Alerts>();
    }
}
