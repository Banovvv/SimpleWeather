using Newtonsoft.Json.Linq;

namespace SimpleWeather
{
    public class Daily
    {
        public Daily(JToken data)
        {
            if (data != null)
            {
                DT = UnixToDateTime(double.Parse(data.SelectToken("dt").ToString()));
                Sunrise = UnixToDateTime(double.Parse(data.SelectToken("sunrise").ToString()));
                Sunset = UnixToDateTime(double.Parse(data.SelectToken("sunset").ToString()));
                Moonrise = UnixToDateTime(double.Parse(data.SelectToken("moonrise").ToString()));
                Moonset = UnixToDateTime(double.Parse(data.SelectToken("moonset").ToString()));
                MoonPhase = double.Parse(data.SelectToken("moon_phase").ToString());
                Temperature = new Temperature(data.SelectToken("temp"));
                FeelsLike = new FeelsLike(data.SelectToken("feels_like"));
                Pressure = double.Parse(data.SelectToken("pressure").ToString());
                Humidity = double.Parse(data.SelectToken("humidity").ToString());
                DewPoint = double.Parse(data.SelectToken("dew_point").ToString());
                WindSpeed = double.Parse(data.SelectToken("wind_speed").ToString());
                if (data.SelectToken("wind_speed") != null)
                {
                    WindGust = double.Parse(data.SelectToken("wind_gust").ToString());
                }
                WindDegee = double.Parse(data.SelectToken("wind_deg").ToString());
                Clouds = double.Parse(data.SelectToken("clouds").ToString());
                Uvi = double.Parse(data.SelectToken("uvi").ToString());
                PrecipitationProbability = double.Parse(data.SelectToken("pop").ToString()) * 100;
                if (data.SelectToken("rain") != null)
                {
                    Rain = double.Parse(data.SelectToken("rain").ToString());
                }
                if (data.SelectToken("snow") != null)
                {
                    Snow = double.Parse(data.SelectToken("snow").ToString());
                }
                Weather = new Weather(data.SelectToken("weather"));
            }
        }

        public DateTime DT { get; }
        public DateTime Sunrise { get; }
        public DateTime Sunset { get; }
        public DateTime Moonrise { get; }
        public DateTime Moonset { get; }
        public double MoonPhase { get; }
        public Temperature? Temperature { get; }
        public FeelsLike? FeelsLike { get; }
        public double Pressure { get; }
        public double Humidity { get; }
        public double DewPoint { get; }
        public double WindSpeed { get; }
        public double WindGust { get; }
        public double WindDegee { get; }
        public double Clouds { get; }
        public double Uvi { get; }
        /// <summary>
        /// Probability of precipitation in percents. The values of the parameter vary between 0 and 100
        /// </summary>
        public double PrecipitationProbability { get; }
        public double? Rain { get; }
        public double? Snow { get; }
        public Weather? Weather { get; }

        private static DateTime UnixToDateTime(double unixTime)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime).ToLocalTime();
        }
    }
}
