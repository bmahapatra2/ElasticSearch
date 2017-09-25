using Nest;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Flight;
using System.Linq;
using System.Collections;


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
            var result = search.GetResult();
            
            Assert.IsTrue(result.FirstOrDefault<FlightDetails>(x => x.FlightName == "airindia") != null);
            Assert.IsTrue(result.FirstOrDefault<FlightDetails>(x => x.FlightName == "jetairways") != null);
            Assert.IsTrue(result.FirstOrDefault<FlightDetails>(x => x.FlightName == "indigo") != null);
        }

        [TestMethod]
        public void CountResult()
        {
            ElasticSearchImplementation search = new ElasticSearchImplementation();
            var result = search.GetResult();
            Assert.AreEqual(5, search.GetResult().Count);
        }
        
        [TestMethod]
        public void DataCheckResult()
        {
            ElasticSearchImplementation search = new ElasticSearchImplementation();
            var result = search.GetResult();
            FlightDetails flight = new FlightDetails();
            Assert.IsTrue(true, search.GetResult().Equals(flight).ToString());
        }

    }
}
 