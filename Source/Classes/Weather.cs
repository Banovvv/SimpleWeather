using Newtonsoft.Json.Linq;

namespace SimpleWeather
{
    internal class Weather
    {
        public Weather(JToken token)
        {

        }

        public int ID { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
