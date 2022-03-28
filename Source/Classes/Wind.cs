using Newtonsoft.Json.Linq;

namespace SimpleWeather
{
    internal class Wind
    {
        public Wind(JToken token)
        {

        }

        public double Speed { get; set; }
        public double Degree { get; set; }
        public double Gust { get; set; }
    }
}
