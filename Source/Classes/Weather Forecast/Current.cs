using Newtonsoft.Json.Linq;

namespace SimpleWeather
{
    public class Current
    {
        public Current(JToken data)
        {
            if (data != null)
            {
                DT = UnixToDateTime(double.Parse(data.SelectToken("dt").ToString()));
                Sunrise = UnixToDateTime(double.Parse(data.SelectToken("sunrise").ToString()));
                Sunset = UnixToDateTime(double.Parse(data.SelectToken("sunset").ToString()));
                Temperature = double.Parse(data.SelectToken("temp").ToString());
                FeelsLike = double.Parse(data.SelectToken("feels_like").ToString());
                Pressure = double.Parse(data.SelectToken("pressure").ToString());
                Humidity = double.Parse(data.SelectToken("humidity").ToString());
                DewPoint = double.Parse(data.SelectToken("dew_point").ToString());
                Clouds = double.Parse(data.SelectToken("clouds").ToString());
                Uvi = double.Parse(data.SelectToken("uvi").ToString());
                Visibility = double.Parse(data.SelectToken("visibility").ToString());
                WindSpeed = double.Parse(data.SelectToken("wind_speed").ToString());
                if (data.SelectToken("wind_gust") != null)
                {
                    WindGust = double.Parse(data.SelectToken("wind_gust").ToString());
                }
                WindDegee = double.Parse(data.SelectToken("wind_deg").ToString());
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

        public DateTime DT { get; }
        public DateTime Sunrise { get; }
        public DateTime Sunset { get; }
        public double Temperature { get; }
        public double FeelsLike { get; }
        public double Pressure { get; }
        public double Humidity { get; }
        public double DewPoint { get; }
        public double Clouds { get; }
        public double Uvi { get; }
        public double Visibility { get; }
        public double WindSpeed { get; }
        public double? WindGust { get; }
        public double WindDegee { get; }
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
