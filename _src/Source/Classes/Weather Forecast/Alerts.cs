using Newtonsoft.Json.Linq;

namespace SimpleWeather
{
    public class Alerts
    {
        public Alerts(JToken data)
        {
            if (data != null)
            {
                SenderName = data.SelectToken("sender_name").ToString();
                Event = data.SelectToken("event").ToString();
                Start = UnixToDateTime(double.Parse(data.SelectToken("start").ToString()));
                End = UnixToDateTime(double.Parse(data.SelectToken("end").ToString()));
                Description = data.SelectToken("description").ToString();
                Tags = data.SelectToken("tags").ToString();
            }
        }

        public string? SenderName { get; }
        public string? Event { get; }
        public DateTime? Start { get; }
        public DateTime? End { get; }
        public string? Description { get; }
        public string? Tags { get; }

        private static DateTime UnixToDateTime(double unixTime)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime).ToLocalTime();
        }
    }
}
