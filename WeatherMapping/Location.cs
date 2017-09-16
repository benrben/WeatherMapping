using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WeatherMapping
{
    public class Location
    {
        private string _SampledCity;
        public Location(string name)
        {
            SampledCity = name;
        }

        public string SampledCity
        {
            get {return _SampledCity;}
            set{_SampledCity = value;}
        }
    }
}