using Newtonsoft.Json.Linq;

namespace SimpleWeather
{
    internal class Sys
    {
        public Sys(JToken data)
        {
            if (data != null)
            {
                Type = int.Parse(data.SelectToken("type").ToString());
                ID = int.Parse(data.SelectToken("id").ToString());
                Country = data.SelectToken("country").ToString();
                Sunrise = UnixToDateTime(double.Parse(data.SelectToken("sunrise").ToString()));
                Sunset = UnixToDateTime(double.Parse(data.SelectToken("sunset").ToString()));
            }
        }

        public int Type { get; set; }
        public int ID { get; set; }
        public string Country { get; set; }
        /// <summary>
        /// Sunrise time converted to your local time
        /// </summary>
        public DateTime Sunrise { get; set; }
        /// <summary>
        /// Sunset time converted to your local time
        /// </summary>
        public DateTime Sunset { get; set; }

        public static DateTime UnixToDateTime(double unixTime)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime).ToLocalTime();
        }
    }
}
