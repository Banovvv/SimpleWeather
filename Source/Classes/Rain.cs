using Newtonsoft.Json.Linq;

namespace SimpleWeather
{
    internal class Rain
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

        public double OneHour { get; set; }
        public double ThreeHours { get; set; }
    }
}
