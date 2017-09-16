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
    public class WeatherDataServiceFactoryTests
    {
        WeatherDataServiceFactory factoryMock = new WeatherDataServiceFactory();
        WeatherData wdMock = null;

        [TestMethod()]
        public void GetWeatherDataServiceValidTest()
        {
            string ValidReq = "OpenWeatherMap";
            factoryMock.GetWeatherDataService(ValidReq);
            Assert.ReferenceEquals(wdMock, factoryMock.GetWeatherDataService(ValidReq));
        }

        [TestMethod()]
        public void GetWeatherDataServiceInvalidTest()
        {
            string ValidReq = "InvalidRequest";
            factoryMock.GetWeatherDataService(ValidReq);
            Assert.ReferenceEquals(null, factoryMock.GetWeatherDataService(ValidReq));
        }
    }
}