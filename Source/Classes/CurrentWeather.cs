using Newtonsoft.Json.Linq;

namespace SimpleWeather
{
    internal class CurrentWeather
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
                City = data.SelectToken("city").ToString();
                StatusCode = statusCode;
            }
        }

        public Coordinates Coordinates { get; set; }
        public Weather Weather { get; set; }
        public string Base { get; set; }
        public Main Main { get; set; }
        public double Visibility { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public Rain Rain { get; set; }
        public Snow Snow { get; set; }
        public Sys Sys { get; set; }
        public int Timezone { get; set; } // UTC +/-
        public int CityID { get; set; }
        public string City { get; set; }
        public int StatusCode { get; set; }
    }
}
