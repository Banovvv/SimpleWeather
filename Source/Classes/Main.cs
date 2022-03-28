using Newtonsoft.Json.Linq;

namespace SimpleWeather
{
    internal class Main
    {
        public Main(JToken data)
        {

        }

        public double Temperature { get; set; }
        public double FeelsLike { get; set; }
        public double TemperatureMin { get; set; }
        public double TemperatureMax { get; set; }
        public double Pressure { get; set; }
        public double Humidity { get; set; }
        public double SeaLevel { get; set; }
        public double GroundLevel { get; set; }
    }
}
