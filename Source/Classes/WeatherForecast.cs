namespace SimpleWeather
{
    internal class WeatherForecast
    {
        public WeatherForecast()
        {

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
        public int Timezone { get; set; } // Timezone / 60 / 60 = UTC +/-
        public int ID { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
    }
}
