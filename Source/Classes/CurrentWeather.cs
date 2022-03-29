using Newtonsoft.Json.Linq;

namespace SimpleWeather
{
    public class CurrentWeather
    {
        public CurrentWeather(string jsonResponse)
        {
            JObject data = JObject.Parse(jsonResponse);
            int statusCode = int.Parse(data.SelectToken("cod").ToString());

            if(statusCode == 200)
            {
                Coordinates = new Coordinates(data.SelectToken("coord"));
                Weather = new Weather(data.SelectToken("weather"));
                Base = data.SelectToken("base").ToString();
                Main = new Main(data.SelectToken("main"));
                if(data.SelectToken("visibility") != null)
                {
                    Visibility = double.Parse(data.SelectToken("visibility").ToString());
                }
                Wind = new Wind(data.SelectToken("wind"));
                Clouds = new Clouds(data.SelectToken("clouds"));
                if (data.SelectToken("rain") != null)
                {
                    Rain = new Rain(data.SelectToken("rain"));
                }
                if (data.SelectToken("snow") != null)
                {
                    Snow = new Snow(data.SelectToken("snow"));
                }
                Sys = new Sys(data.SelectToken("sys"));
                Timezone = int.Parse(data.SelectToken("timezone").ToString()) / 360;
                CityID = int.Parse(data.SelectToken("id").ToString());
                City = data.SelectToken("name").ToString();
                StatusCode = statusCode;
            }
        }

        public Coordinates Coordinates { get; }
        public Weather Weather { get; }
        public string Base { get; }
        public Main Main { get; }
        public double Visibility { get; }
        public Wind Wind { get; }
        public Clouds Clouds { get; }
        public Rain Rain { get; }
        public Snow Snow { get; }
        public Sys Sys { get; }
        /// <summary>
        /// UTC (+/-) hour/s
        /// </summary>
        public int Timezone { get; }
        public int CityID { get; }
        public string City { get; }
        public int StatusCode { get; }
    }
}
