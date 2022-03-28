using Newtonsoft.Json.Linq;

namespace SimpleWeather
{
    public class Main
    {
        public Main(JToken data)
        {
            if(data != null)
            {
                Temperature = double.Parse(data.SelectToken("temp").ToString());
                FeelsLike = double.Parse(data.SelectToken("feels_like").ToString());
                TemperatureMin = double.Parse(data.SelectToken("temp_min").ToString());
                TemperatureMax = double.Parse(data.SelectToken("temp_max").ToString());
                Pressure = double.Parse(data.SelectToken("pressure").ToString());
                Humidity = double.Parse(data.SelectToken("humidity").ToString());
                if (data.SelectToken("sea_level") != null)
                {
                    SeaLevel = double.Parse(data.SelectToken("sea_level").ToString()); 
                }
                if (data.SelectToken("grnd_level") != null)
                {
                    GroundLevel = double.Parse(data.SelectToken("grnd_level").ToString()); 
                }
            }
        }

        /// <summary>
        /// Temperature. Default Unit: Celsius
        /// </summary>
        public double Temperature { get; set; }
        /// <summary>
        /// Temperature. This temperature parameter accounts for the human perception of weather. Default Unit: Celsius
        /// </summary>
        public double FeelsLike { get; set; }
        /// <summary>
        /// Minimum temperature at the moment. This is minimal currently observed temperature (within large megalopolises and urban areas). Default Unit: Celsius
        /// </summary>
        public double TemperatureMin { get; set; }
        /// <summary>
        /// Maximum temperature at the moment. This is maximal currently observed temperature (within large megalopolises and urban areas). Default Unit: Celsius
        /// </summary>
        public double TemperatureMax { get; set; }
        /// <summary>
        /// Atmospheric pressure (on the sea level, if there is no SeaLevel or GroundLevel data), hPa
        /// </summary>
        public double Pressure { get; set; }
        /// <summary>
        /// Humidity, %
        /// </summary>
        public double Humidity { get; set; }
        /// <summary>
        /// Atmospheric pressure on the sea level, hPa
        /// </summary>
        public double SeaLevel { get; set; }
        /// <summary>
        /// Atmospheric pressure on the ground level, hPa
        /// </summary>
        public double GroundLevel { get; set; }
    }
}
