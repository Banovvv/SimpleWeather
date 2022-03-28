using Newtonsoft.Json.Linq;

namespace SimpleWeather
{
    public class Rain
    {
        public Rain(JToken data)
        {
            if(data != null)
            {
                if(data.SelectToken("1h") != null)
                {
                    OneHour = double.Parse(data.SelectToken("1h").ToString());
                }

                if (data.SelectToken("3h") != null)
                {
                    ThreeHours = double.Parse(data.SelectToken("3h").ToString());
                }
            }
        }
        /// <summary>
        /// Rain volume for the last 1 hour, mm
        /// </summary>
        public double OneHour { get; set; }
        /// <summary>
        /// Rain volume for the last 3 hours, mm
        /// </summary>
        public double ThreeHours { get; set; }
    }
}
