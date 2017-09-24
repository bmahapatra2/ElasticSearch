using Nest;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Flight;
using System.Linq;

namespace ElasticSearchDemo
{
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {   
            ElasticSearchImplementation search = new ElasticSearchImplementation();
            search.AddNewIndex(new FlightDetails(1, "airindia",  "india"));
            search.AddNewIndex(new FlightDetails(2, "jetairways",  "delhi"));
            search.AddNewIndex(new FlightDetails(3, "indigo", "mumbai"));
            search.AddNewIndex(new FlightDetails(4, "emirates",  "chennai"));
            search.AddNewIndex(new FlightDetails(5, "lufthansa", "kolkata"));
            search.AddNewIndex(new FlightDetails(4, "spicejet",  "indore"));
        }
    
        [TestMethod]
        public void GetResultTest()
        {
            ElasticSearchImplementation search = new ElasticSearchImplementation();
            FlightDetails details = new FlightDetails();
            var result = search.GetResult();
            //result.Contains("airindia";
            Assert.IsFalse(result.FirstOrDefault<FlightDetails>(x => x.FlightName == "airindia") != null);
            Assert.IsFalse(result.FirstOrDefault<FlightDetails>(x => x.FlightName == "jetairways") != null);
            Assert.IsFalse(result.FirstOrDefault<FlightDetails>(x => x.FlightName == "indigo") != null);
        }
    }
}
