using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMapping;

class Program
{
    static void Main(string[] args)
    {
        WeatherDataServiceFactory factory = new WeatherDataServiceFactory();
        WeatherData wd = (WeatherData)factory.GetWeatherDataService(factory.OPEN_WEATHER_MAP);
        wd = wd.GetWeatherData(new Location("london"));
        wd.ShowMappedWeatherData();

    }
}
