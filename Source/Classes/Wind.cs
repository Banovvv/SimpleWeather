using Newtonsoft.Json.Linq;

namespace SimpleWeather
{
    public class Wind
    {
        public Wind(JToken data)
        {
            if(data != null)
            {
                Speed = double.Parse(data.SelectToken("speed").ToString());
                Degree = double.Parse(data.SelectToken("deg").ToString());
                if (data.SelectToken("gust") != null)
                {
                    Gust = double.Parse(data.SelectToken("gust").ToString()); 
                }
            }
        }
        /// <summary>
        /// Wind speed. Default Unit: meter/sec
        /// </summary>
        public double Speed { get; }
        /// <summary>
        /// Wind direction, degrees (meteorological)
        /// </summary>
        public double Degree { get; }
        /// <summary>
        /// Wind gust. Default Unit: meter/sec
        /// </summary>
        public double Gust { get; }
    }
}
