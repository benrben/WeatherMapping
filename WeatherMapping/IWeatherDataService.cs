using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMapping
{
    public interface IWeatherDataService
    {
        WeatherData GetWeatherData (Location location);              // Get current weather data per city
    }
}
