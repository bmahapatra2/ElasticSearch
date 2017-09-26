using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using LoggingElasticSearch;

namespace LogTester
{
    [TestClass]
    public class UnitTest1
    {
        
        public UnitTest1()
        {
            ElasticSearchImplementation search = new ElasticSearchImplementation();
            search.AddNewIndex(new Log("1", "172.16.14.49", "213", DateTime.Parse("16-09-1995"), DateTime.Parse("16-09-1995")));
            search.AddNewIndex(new Log("2", "172.16.14.25", "875", DateTime.Parse("17-09-1995"), DateTime.Parse("17-09-1995")));
            search.AddNewIndex(new Log("3", "172.16.14.32", "985", DateTime.Parse("18-09-1995"), DateTime.Parse("18-09-1995")));
            search.AddNewIndex(new Log("4", "172.16.14.32", "541", DateTime.Parse("19-09-1995"), DateTime.Parse("19-09-1995")));
        }

        [TestMethod]
        public void LogMaintainer()
        {
            ElasticSearchImplementation search = new ElasticSearchImplementation();
            var result = search.GetResult();
            Assert.IsTrue(result.FirstOrDefault<Log>(x => x.Status == "1") != null);
            Assert.IsTrue(result.FirstOrDefault<Log>(x => x.Status == "2") != null);
            Assert.IsTrue(result.FirstOrDefault<Log>(x => x.Status == "3") != null);
        }

        [TestMethod]
        public void CountResult()
        {
            ElasticSearchImplementation search = new ElasticSearchImplementation();
            var result = search.GetResult();
            Assert.AreEqual(10, search.GetResult().Count);
        }

        [TestMethod]
        public void DataCheckResult()
        {
            ElasticSearchImplementation search = new ElasticSearchImplementation();
            var result = search.GetResult();
            Log log = new Log("3", "172.16.14.32", "985", DateTime.Parse("18-09-1995"), DateTime.Parse("18-09-1995"));
            Assert.IsTrue(true, search.GetResult().Equals(log).ToString());
        }

    }
}
