using Newtonsoft.Json.Linq;

namespace SimpleWeather
{
    public class Wind
    {
        public Wind(JToken data)
        {
            if (data != null)
            {
                Speed = double.Parse(data.SelectToken("speed").ToString());
                Degree = double.Parse(data.SelectToken("deg").ToString());
                if (data.SelectToken("gust") != null)
                {
                    Gust = double.Parse(data.SelectToken("gust").ToString());
                }
                WindDirectionShort = GetWindDirectionShort(Degree);
                WindDirectionLong = GetWindDirectionLong(Degree);
            }
        }
        /// <summary>
        /// Wind speed. Default Unit: meter/sec
        /// </summary>
        public double Speed { get; }
        /// <summary>
        /// Wind direction, degrees (meteorological)
        /// </summary>
        public double Degree { get; }
        /// <summary>
        /// Wind gust. Default Unit: meter/sec
        /// </summary>
        public string WindDirectionShort { get; }
        public string WindDirectionLong { get; }
        public double Gust { get; }

        public static string GetWindDirectionShort(double windDegree)
        {
            string windDirectionShort = string.Empty;

            if (windDegree >= 0 && windDegree <= 11.25 || windDegree > 348.75 && windDegree <= 360)
            {
                windDirectionShort = "N";
            }
            else if(windDegree > 11.25 && windDegree <= 33.75)
            {
                windDirectionShort = "NNE";
            }
            else if(windDegree > 33.75 && windDegree <= 56.25)
            {
                windDirectionShort = "NE";
            }
            else if (windDegree > 56.25 && windDegree <= 78.75)
            {
                windDirectionShort = "ENE";
            }
            else if (windDegree > 78.75 && windDegree <= 101.25)
            {
                windDirectionShort = "E";
            }
            else if (windDegree > 101.25 && windDegree <= 123.75)
            {
                windDirectionShort = "ESE";
            }
            else if (windDegree > 123.75 && windDegree <= 146.25)
            {
                windDirectionShort = "SE";
            }
            else if (windDegree > 146.25 && windDegree <= 168.75)
            {
                windDirectionShort = "SSE";
            }
            else if (windDegree > 168.75 && windDegree <= 191.25)
            {
                windDirectionShort = "S";
            }
            else if (windDegree > 191.25 && windDegree <= 213.75)
            {
                windDirectionShort = "SSW";
            }
            else if (windDegree > 213.75 && windDegree <= 236.25)
            {
                windDirectionShort = "SW";
            }
            else if (windDegree > 236.25 && windDegree <= 258.75)
            {
                windDirectionShort = "WSW";
            }
            else if (windDegree > 258.75 && windDegree <= 281.25)
            {
                windDirectionShort = "W";
            }
            else if (windDegree > 281.25 && windDegree <= 303.75)
            {
                windDirectionShort = "WNW";
            }
            else if (windDegree > 303.75 && windDegree <= 326.25)
            {
                windDirectionShort = "NW";
            }
            else if (windDegree > 326.25 && windDegree <= 348.75)
            {
                windDirectionShort = "NNW";
            }

            return windDirectionShort;
        }

        public static string GetWindDirectionLong(double windDegree)
        {
            string windDirectionLong = string.Empty;

            if (windDegree >= 0 && windDegree <= 11.25 || windDegree > 348.75 && windDegree <= 360)
            {
                windDirectionLong = "North";
            }
            else if (windDegree > 11.25 && windDegree <= 33.75)
            {
                windDirectionLong = "North-northeast";
            }
            else if (windDegree > 33.75 && windDegree <= 56.25)
            {
                windDirectionLong = "Northeast";
            }
            else if (windDegree > 56.25 && windDegree <= 78.75)
            {
                windDirectionLong = "East-northeast";
            }
            else if (windDegree > 78.75 && windDegree <= 101.25)
            {
                windDirectionLong = "East";
            }
            else if (windDegree > 101.25 && windDegree <= 123.75)
            {
                windDirectionLong = "East-southeast";
            }
            else if (windDegree > 123.75 && windDegree <= 146.25)
            {
                windDirectionLong = "Southeast";
            }
            else if (windDegree > 146.25 && windDegree <= 168.75)
            {
                windDirectionLong = "South-southeast";
            }
            else if (windDegree > 168.75 && windDegree <= 191.25)
            {
                windDirectionLong = "South";
            }
            else if (windDegree > 191.25 && windDegree <= 213.75)
            {
                windDirectionLong = "South-southwest";
            }
            else if (windDegree > 213.75 && windDegree <= 236.25)
            {
                windDirectionLong = "Southwest";
            }
            else if (windDegree > 236.25 && windDegree <= 258.75)
            {
                windDirectionLong = "West-southwest";
            }
            else if (windDegree > 258.75 && windDegree <= 281.25)
            {
                windDirectionLong = "West";
            }
            else if (windDegree > 281.25 && windDegree <= 303.75)
            {
                windDirectionLong = "West-northwest";
            }
            else if (windDegree > 303.75 && windDegree <= 326.25)
            {
                windDirectionLong = "Northwest";
            }
            else if (windDegree > 326.25 && windDegree <= 348.75)
            {
                windDirectionLong = "North-northwest";
            }

            return windDirectionLong;
        }
    }

}
