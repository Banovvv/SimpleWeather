using Newtonsoft.Json.Linq;

namespace SimpleWeather
{
    internal class Rain
    {
        public Rain(JToken token)
        {

        }

        public double OneHour { get; set; }
        public double ThreeHours { get; set; }
    }
}
