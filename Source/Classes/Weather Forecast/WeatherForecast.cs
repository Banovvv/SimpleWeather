using Newtonsoft.Json.Linq;

namespace SimpleWeather
{
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

        public double Latitude { get; }
        public double Longitude { get; }
        public string? Timezone { get; }
        public int TimezoneOffset { get; }
        public Current? Current { get; }
        public List<Hourly>? Hourly { get; } = new List<Hourly>();
        public List<Daily>? Daily { get; } = new List<Daily>();
        public List<Alerts>? Alerts { get; } = new List<Alerts>();
    }
}
