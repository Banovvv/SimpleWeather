using Newtonsoft.Json.Linq;

namespace SimpleWeather
{
    public class Sys
    {
        public Sys(JToken data)
        {
            if (data != null)
            {
                Type = int.Parse(data.SelectToken("type").ToString());
                ID = int.Parse(data.SelectToken("id").ToString());
                Country = data.SelectToken("country").ToString();
                // TODO: Extract only time
                Sunrise = UnixToDateTime(double.Parse(data.SelectToken("sunrise").ToString()));
                Sunset = UnixToDateTime(double.Parse(data.SelectToken("sunset").ToString()));
            }
        }

        public int Type { get; }
        public int ID { get; }
        public string Country { get; }
        /// <summary>
        /// Sunrise time converted to your local time
        /// </summary>
        public DateTime Sunrise { get; }
        /// <summary>
        /// Sunset time converted to your local time
        /// </summary>
        public DateTime Sunset { get; }

        public static DateTime UnixToDateTime(double unixTime)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime).ToLocalTime();
        }
    }
}
