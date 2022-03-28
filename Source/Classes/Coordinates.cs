﻿using Newtonsoft.Json.Linq;

namespace SimpleWeather
{
    internal class Coordinates
    {
        public Coordinates(JToken data)
        {
            if (data != null)
            {
                Longitude = double.Parse(data.SelectToken("lon").ToString());
                Latitude = double.Parse(data.SelectToken("lat").ToString()); 
            }
        }

        /// <summary>
        /// City geo location, longitude
        /// </summary>
        public double Longitude { get; set; }
        /// <summary>
        /// City geo location, latitude
        /// </summary>
        public double Latitude { get; set; }
    }
}
