using Newtonsoft.Json.Linq;

namespace SimpleWeather
{
    public class Weather
    {
        public Weather(JToken data)
        {
            if (data != null)
            {
                ID = int.Parse(data.SelectToken("id").ToString());
                Main = data.SelectToken("main").ToString();
                Description = data.SelectToken("description").ToString();
                Icon = data.SelectToken("icon").ToString();
            }
        }

        /// <summary>
        /// Weather condition ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Group of weather parameters (Rain, Snow, Extreme etc.)
        /// </summary>
        public string Main { get; set; }
        /// <summary>
        /// Weather condition within the group
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Weather icon ID
        /// </summary>
        public string Icon { get; set; }
    }
}
