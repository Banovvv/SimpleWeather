using Newtonsoft.Json.Linq;

namespace SimpleWeather
{
    public class Hourly
    {
        public Hourly(JToken data)
        {
            if (data != null)
            {
                // DateTime
                DT = UnixToDateTime(double.Parse(data.SelectToken("dt").ToString()));
                Temperature = double.Parse(data.SelectToken("temp").ToString());
                FeelsLike = double.Parse(data.SelectToken("feels_like").ToString());
                Pressure = double.Parse(data.SelectToken("pressure").ToString());
                Humidity = double.Parse(data.SelectToken("humidity").ToString());
                DewPoint = double.Parse(data.SelectToken("dew_point").ToString());
                Uvi = double.Parse(data.SelectToken("uvi").ToString());
                Clouds = double.Parse(data.SelectToken("clouds").ToString());
                Visibility = double.Parse(data.SelectToken("visibility").ToString());
                WindSpeed = double.Parse(data.SelectToken("wind_speed").ToString());
                WindDirectionShort = Wind.GetWindDirectionShort(WindDegee);
                WindDirectionLong = Wind.GetWindDirectionLong(WindDegee);
                if (data.SelectToken("wind_gust") != null)
                {
                    WindGust = double.Parse(data.SelectToken("wind_gust").ToString());
                }
                WindDegee = double.Parse(data.SelectToken("wind_deg").ToString());
                PrecipitationProbability = Math.Round(double.Parse(data.SelectToken("pop").ToString()) * 100);
                if (data.SelectToken("rain") != null)
                {
                    Rain = new Rain(data.SelectToken("rain"));
                }
                if (data.SelectToken("snow") != null)
                {
                    Snow = new Snow(data.SelectToken("snow"));
                }
                Weather = new Weather(data.SelectToken("weather"));
            }
        }
        /// <summary>
        /// Time of the forecasted data, UTC
        /// </summary>
        public DateTime DT { get; }
        /// <summary>
        /// Temperature
        /// </summary>
        public double Temperature { get; }
        /// <summary>
        /// Temperature. This accounts for the human perception of weather.
        /// </summary>
        public double FeelsLike { get; }
        /// <summary>
        /// Atmospheric pressure on the sea level, hPa
        /// </summary>
        public double Pressure { get; }
        /// <summary>
        /// Humidity, %
        /// </summary>
        public double Humidity { get; }
        /// <summary>
        ///  Atmospheric temperature (varying according to pressure and humidity) below which water droplets begin to condense and dew can form.
        /// </summary>
        public double DewPoint { get; }
        /// <summary>
        /// UV index
        /// </summary>
        public double Uvi { get; }
        /// <summary>
        /// Cloudiness, %
        /// </summary>
        public double Clouds { get; }
        public double Visibility { get; }
        /// <summary>
        /// Wind speed. Default Unit: meter/sec
        /// </summary>
        public double WindSpeed { get; }
        /// <summary>
        /// Wind gust. Default Unit: meter/sec
        /// </summary>
        public double WindGust { get; }
        /// <summary>
        /// Wind direction, degrees (meteorological)
        /// </summary>
        public double WindDegee { get; }
        /// <summary>
        /// Short wind direction represented by a string (N, E, S, W, etc.)
        /// </summary>
        public string? WindDirectionShort { get; }
        /// <summary>
        /// Long wind direction represented by a string (North, East, South, West, etc.)
        /// </summary>
        public string? WindDirectionLong { get; }
        /// <summary>
        /// Probability of precipitation in percents. The values of the parameter vary between 0 and 100
        /// </summary>
        public double PrecipitationProbability { get; }
        public Rain? Rain { get; }
        public Snow? Snow { get; }
        public Weather? Weather { get; }

        private static DateTime UnixToDateTime(double unixTime)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime).ToLocalTime();
        }
    }
}
