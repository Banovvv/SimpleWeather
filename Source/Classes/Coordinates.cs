using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWeather
{
    internal class Coordinates
    {
        public Coordinates(JToken token)
        {

        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
