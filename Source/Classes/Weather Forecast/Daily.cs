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
                MoonPhase = DoubleToMoonPhase(double.Parse(data.SelectToken("moon_phase").ToString()));
                Temperature = new Temperature(data.SelectToken("temp"));
                FeelsLike = new FeelsLike(data.SelectToken("feels_like"));
                Pressure = double.Parse(data.SelectToken("pressure").ToString());
                Humidity = double.Parse(data.SelectToken("humidity").ToString());
                DewPoint = double.Parse(data.SelectToken("dew_point").ToString());
                WindSpeed = double.Parse(data.SelectToken("wind_speed").ToString());
                if (data.SelectToken("wind_gust") != null)
                {
                    WindGust = double.Parse(data.SelectToken("wind_gust").ToString());
                }
                WindDegee = double.Parse(data.SelectToken("wind_deg").ToString());
                WindDirectionShort = Wind.GetWindDirectionShort(WindDegee);
                WindDirectionLong = Wind.GetWindDirectionLong(WindDegee);
                Clouds = double.Parse(data.SelectToken("clouds").ToString());
                Uvi = double.Parse(data.SelectToken("uvi").ToString());
                PrecipitationProbability = Math.Round(double.Parse(data.SelectToken("pop").ToString()) * 100);
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
        /// <summary>
        /// Moon phase
        /// </summary>
        public string? MoonPhase { get; }
        public Temperature? Temperature { get; }
        public FeelsLike? FeelsLike { get; }
        public double Pressure { get; }
        public double Humidity { get; }
        public double DewPoint { get; }
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
        public string WindDirectionShort { get; }
        /// <summary>
        /// Long wind direction represented by a string (North, East, South, West, etc.)
        /// </summary>
        public string WindDirectionLong { get; }
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

        private static string DoubleToMoonPhase(double phase)
        {
            string moonPhase = string.Empty;

            if (phase >= 0.000 && phase <= 0.062)
            {
                moonPhase = "New Moon";
            }
            else if(phase > 0.062 && phase < 0.187)
            {
                moonPhase = "Waxing Crescent";
            }
            else if(phase >= 0.187 && phase <= 0.312)
            {
                moonPhase = "First Quarter";
            }
            else if (phase > 0.312 && phase < 0.437)
            {
                moonPhase = "Waxing Gibbous";
            }
            else if (phase >= 0.437 && phase <= 0.562)
            {
                moonPhase = "Full Moon";
            }
            else if (phase > 0.562 && phase < 0.687)
            {
                moonPhase = "Waning Gibbous";
            }
            else if (phase >= 0.687 && phase <= 0.812)
            {
                moonPhase = "Last Quarter";
            }
            else if (phase > 0.812 && phase < 0.938)
            {
                moonPhase = "Waning Crescent";
            }
            else if (phase >= 0.938 && phase <= 1.000)
            {
                moonPhase = "New Moon";
            }

            return moonPhase;
        }
    }
}
