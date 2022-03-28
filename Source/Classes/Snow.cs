using Newtonsoft.Json.Linq;

namespace SimpleWeather
{
    internal class Snow
    {
        public Snow(JToken token)
        {

        }

        public double OneHour { get; set; }
        public double ThreeHours { get; set; }
    }
}
