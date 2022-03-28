using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWeather
{
    internal class Clouds
    {
        public Clouds(JToken token)
        {

        }

        public double Cloudiness { get; set; }
    }
}
