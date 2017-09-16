using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace WeatherMapping
{
    public sealed class WeatherData :  IWeatherDataService 
    {
        private static readonly log4net.ILog log =
        log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly WeatherData instance = new WeatherData();
        private const string API_KEY = "&appid=fdce6f4274bce1e6d9e37d0255ca9cbe";
        private const string XML_FORMAT = "&mode=xml";
        private const string PrefixURL = "http://api.openweathermap.org/data/2.5/weather?q=";
        private string _URL;
        private Location StoredLocation;
        private string _SampledCityId;
        private string _CoordLon;
        private string _CoordLat;
        private string _Country;
        private string _SunRiseTime;
        private string _SunSetTime;
        private string _TemperatureValue;
        private string _TemperatureUnit;
        private string _TemperatureMin;
        private string _TemperatureMax;
        private string _Humidity;
        private string _Pressure;
        private string _WindSpeed;
        private string _WindDirection;
        private string _Clouds;
        private string _Precipitation;
        private string _LastUpdate;

        private WeatherData() { }

        public static WeatherData Instance
        {
            get
            {
                return instance;
            }
        }
        public string URL
        {
            get
            {
                return _URL;
            }

            set
            {
                _URL = value;
            }
        }
        public string SampledCityId
        {
            get
            {
                return _SampledCityId;
            }

            set
            {
                _SampledCityId = value;
            }
        }
        public string CoordLon
        {
            get
            {
                return _CoordLon;
            }

            set
            {
                _CoordLon = value;
            }
        }
        public string CoordLat
        {
            get
            {
                return _CoordLat;
            }

            set
            {
                _CoordLat = value;
            }
        }
        public string Country
        {
            get
            {
                return _Country;
            }

            set
            {
                _Country = value;
            }
        }
        public string SunRiseTime
        {
            get
            {
                return _SunRiseTime;
            }

            set
            {
                _SunRiseTime = value;
            }
        }

        public string SunSetTime
        {
            get
            {
                return _SunSetTime;
            }

            set
            {
                _SunSetTime = value;
            }
        }
        public string TemperatureValue
        {
            get
            {
                return _TemperatureValue;
            }

            set
            {
                _TemperatureValue = value;
            }
        }
        public string TemperatureUnit
        {
            get
            {
                return _TemperatureUnit;
            }

            set
            {
                _TemperatureUnit = value;
            }
        }
        public string TemperatureMin
        {
            get
            {
                return _TemperatureMin;
            }

            set
            {
                _TemperatureMin = value;
            }
        }
        public string TemperatureMax
        {
            get
            {
                return _TemperatureMax;
            }

            set
            {
                _TemperatureMax = value;
            }
        }
        public string Humidity
        {
            get
            {
                return _Humidity;
            }

            set
            {
                _Humidity = value;
            }
        }
        public string Pressure
        {
            get
            {
                return _Pressure;
            }

            set
            {
                _Pressure = value;
            }
        }
        public string WindSpeed
        {
            get
            {
                return _WindSpeed;
            }

            set
            {
                _WindSpeed = value;
            }
        }
        public string WindDirection
        {
            get
            {
                return _WindDirection;
            }

            set
            {
                _WindDirection = value;
            }
        }
        public string Clouds
        {
            get
            {
                return _Clouds;
            }

            set
            {
                _Clouds = value;
            }
        }
        public string Precipitation
        {
            get
            {
                return _Precipitation;
            }

            set
            {
                _Precipitation = value;
            }
        }
        public string LastUpdate
        {
            get
            {
                return _LastUpdate;
            }

            set
            {
                _LastUpdate = value;
            }
        }
        public void URLBuilder(string CityName)
        {
            URL = PrefixURL + CityName + XML_FORMAT + API_KEY;
            log.Info("The RESTful API call was generated successfuly");
        }
        public void XMLReader(string url)
        {
            try
            {
                WebClient client = new WebClient();
                String XMLData = client.DownloadString(url);
                XDocument ParsedXML = XDocument.Parse(XMLData);

                SampledCityId = ParsedXML.Descendants("city").Attributes("id").First().Value;
                CoordLon = ParsedXML.Descendants("coord").Attributes("lon").First().Value;
                CoordLat = ParsedXML.Descendants("coord").Attributes("lat").First().Value;
                Country = ParsedXML.Descendants("country").First().Value;
                SunRiseTime = ParsedXML.Descendants("sun").Attributes("rise").First().Value;
                SunSetTime = ParsedXML.Descendants("sun").Attributes("set").First().Value;
                TemperatureValue = ParsedXML.Descendants("temperature").Attributes("value").First().Value;
                TemperatureUnit = ParsedXML.Descendants("temperature").Attributes("unit").First().Value;
                TemperatureMin = ParsedXML.Descendants("temperature").Attributes("min").First().Value;
                TemperatureMax = ParsedXML.Descendants("temperature").Attributes("max").First().Value;
                Humidity = ParsedXML.Descendants("humidity").Attributes("value").First().Value;
                Pressure = ParsedXML.Descendants("pressure").Attributes("value").First().Value;
                WindSpeed = ParsedXML.Descendants("speed").Attributes("value").First().Value;
                WindDirection = ParsedXML.Descendants("direction").Attributes("name").First().Value;
                Clouds = ParsedXML.Descendants("clouds").Attributes("name").First().Value;
                Precipitation = ParsedXML.Descendants("precipitation").Attributes("mode").First().Value;
                LastUpdate = ParsedXML.Descendants("lastupdate").Attributes("value").First().Value;

                log.Info("XML data was mapped and stored successfuly!");
            }
            catch (XmlException e)
            {
                log.Info("Unexpected error - seems like location not found! {0}", e);
            }  
        }
        public WeatherData GetWeatherData(Location location)
        {
            StoredLocation = location;
            URLBuilder(location.SampledCity);
            log.Info("Starting with fetching data from: " + URL);
            XMLReader(URL);
            return this;
        }
        public void ShowMappedWeatherData()
        {
            Console.WriteLine("The data was fetched from:\n {0}\n", URL);
            Console.WriteLine("City Name: {0}", StoredLocation.SampledCity);
            Console.WriteLine("City ID: {0}", SampledCityId);
            Console.WriteLine("Coord Lon: {0}", CoordLon);
            Console.WriteLine("Coord Lat: {0}", CoordLat);
            Console.WriteLine("Country: {0}", Country);
            Console.WriteLine("Sunrise Time: {0}", SunRiseTime);
            Console.WriteLine("Sunset Time: {0}", SunSetTime);
            Console.WriteLine("Temperature Value: {0}", TemperatureValue);
            Console.WriteLine("Temperature Unit: {0}", TemperatureUnit);
            Console.WriteLine("Temperature Min: {0}", TemperatureMin);
            Console.WriteLine("Temperature Max: {0}", TemperatureMax);
            Console.WriteLine("Humidity: {0}", Humidity);
            Console.WriteLine("Pressure: {0}", Pressure);
            Console.WriteLine("Wind Speed: {0}", WindSpeed);
            Console.WriteLine("Wind Direction: {0}", WindDirection);
            Console.WriteLine("Clouds: {0}", Clouds);
            Console.WriteLine("Precipitation: {0}\n", Precipitation);
            Console.WriteLine("Data was last updated at: {0}", LastUpdate);
            Console.ReadKey();
        }
    }
}
