using Newtonsoft.Json.Linq;

namespace SimpleWeather
{
    public class Weather
    {
        public Weather(JToken data)
        {
            if (data != null)
            {
                ID = int.Parse(data.FirstOrDefault().SelectToken("id").ToString());
                Main = data.FirstOrDefault().SelectToken("main").ToString();
                Description = data.FirstOrDefault().SelectToken("description").ToString();
                Icon = data.FirstOrDefault().SelectToken("icon").ToString();
            }
        }

        /// <summary>
        /// Weather condition ID
        /// </summary>
        public int ID { get; }
        /// <summary>
        /// Group of weather parameters (Rain, Snow, Extreme etc.)
        /// </summary>
        public string Main { get; }
        /// <summary>
        /// Weather condition within the group
        /// </summary>
        public string Description { get; }
        /// <summary>
        /// Weather icon ID
        /// </summary>
        public string Icon { get; }
    }
}
