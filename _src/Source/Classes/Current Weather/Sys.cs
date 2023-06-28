using Newtonsoft.Json.Linq;

namespace SimpleWeather
{
    public class Sys
    {
        public Sys(JToken data)
        {
            if (data != null)
            {
                if (data.SelectToken("type") != null)
                {
                    Type = int.Parse(data.SelectToken("type").ToString()); 
                }
                if (data.SelectToken("id") != null)
                {
                    ID = int.Parse(data.SelectToken("id").ToString()); 
                }
                Country = data.SelectToken("country").ToString();
                Sunrise = UnixToDateTime(double.Parse(data.SelectToken("sunrise").ToString()));
                Sunset = UnixToDateTime(double.Parse(data.SelectToken("sunset").ToString()));
                SunriseTime = DateTimeToSimpleTime(Sunrise);
                SunsetTime = DateTimeToSimpleTime(Sunset);
            }
        }

        public int? Type { get; }
        public int? ID { get; }
        public string Country { get; }
        /// <summary>
        /// A DateTime object representing sunrise time converted to your local time
        /// </summary>
        public DateTime Sunrise { get; }
        /// <summary>
        /// Time of sunrise in the format HH:mm
        /// </summary>
        public string SunriseTime { get; }
        /// <summary>
        /// A DateTime object representing sunset time converted to your local time
        /// </summary>
        public DateTime Sunset { get; }
        /// <summary>
        /// Time of sunset in the format HH:mm
        /// </summary>
        public string SunsetTime { get; }

        private static DateTime UnixToDateTime(double unixTime)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime).ToLocalTime();
        }

        private static string DateTimeToSimpleTime(DateTime dateTime)
        {
            return dateTime.ToString("t");
        }
    }
}
