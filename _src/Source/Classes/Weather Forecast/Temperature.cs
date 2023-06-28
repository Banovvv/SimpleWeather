using Newtonsoft.Json.Linq;

namespace SimpleWeather
{
    public class Temperature
    {
        public Temperature(JToken data)
        {
            if (data != null)
            {
                Morning = double.Parse(data.SelectToken("morn").ToString());
                Day = double.Parse(data.SelectToken("day").ToString());
                Evening = double.Parse(data.SelectToken("eve").ToString());
                Night = double.Parse(data.SelectToken("night").ToString());
                Min = double.Parse(data.SelectToken("min").ToString());
                Max = double.Parse(data.SelectToken("max").ToString());
            }
        }

        public double Morning { get; }
        public double Day { get; }
        public double Evening { get; }
        public double Night { get; }
        public double Min { get; }
        public double Max { get; }
    }
}
