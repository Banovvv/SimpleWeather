using Newtonsoft.Json.Linq;

namespace SimpleWeather
{
    internal class Coordinates
    {
        public Coordinates(JToken data)
        {
            if (data != null)
            {
                Longitude = double.Parse(data.SelectToken("lon").ToString());
                Latitude = double.Parse(data.SelectToken("lat").ToString()); 
            }
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
