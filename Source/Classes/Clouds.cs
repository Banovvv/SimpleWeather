using Newtonsoft.Json.Linq;

namespace SimpleWeather
{
    internal class Clouds
    {
        public Clouds(JToken data)
        {
            if (data != null)
            {
                Cloudiness = double.Parse(data.SelectToken("all").ToString()); 
            }
        }

        /// <summary>
        /// Cloudiness, %
        /// </summary>
        public double Cloudiness { get; set; }
    }
}
