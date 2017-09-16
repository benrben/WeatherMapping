using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMapping
{
   public class WeatherDataServiceFactory
    {
        private static readonly log4net.ILog log =
        log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string _OPEN_WEATHER_MAP = "OpenWeatherMap";
        public string OPEN_WEATHER_MAP
        {
            get
            {
                return _OPEN_WEATHER_MAP;
            }
        }
        private IWeatherDataService instance = WeatherData.Instance;

        public WeatherDataServiceFactory()
        { }

       public IWeatherDataService GetWeatherDataService(string request)
        {
            try
            {
                if (request == OPEN_WEATHER_MAP)
                {
                    return instance;
                }
            }
            catch(WeatherDataServiceException e)
            {
                log.Error("Wrong request was sended!, WeatherDataServiceException");
            }
            return null;
        }
    }
}