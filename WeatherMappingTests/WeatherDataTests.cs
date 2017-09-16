using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMapping.Tests
{
    [TestClass()]
    public class WeatherDataTests
    {
        WeatherData wd = WeatherData.Instance;
        Location city = new Location("tel aviv");
        string MockURL;

        [TestMethod()]
        public void URLBuilderTest()
        {
            MockURL = "http://api.openweathermap.org/data/2.5/weather?q=" +
               city.SampledCity +
               "&mode=xml" +
               "&appid=fdce6f4274bce1e6d9e37d0255ca9cbe";

            wd.URLBuilder(city.SampledCity);

            Assert.AreEqual(MockURL, wd.URL);
        }

        [TestMethod()]
        public void XMLReaderTest()
        {
            MockURL = "http://api.openweathermap.org/data/2.5/weather?q=" +
            city.SampledCity +
            "&mode=xml" +
            "&appid=fdce6f4274bce1e6d9e37d0255ca9cbe";
            wd.XMLReader(MockURL);
            Assert.AreEqual("IL", wd.Country);
        }

        [TestMethod()]
        public void GetWeatherDataTest()
        {
            wd.GetWeatherData(city);
            Assert.AreNotEqual(null, wd);
        }
    }
}