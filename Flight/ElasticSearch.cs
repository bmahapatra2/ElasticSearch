using Nest;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Flight
{
    public class ElasticSearchImplementation
    {
        ElasticClient client = null;
        public ElasticSearchImplementation()
        {
            var uri = new Uri("http://172.16.14.49:9200");
            var settings = new ConnectionSettings(uri);
            client = new ElasticClient(settings);
            settings.DefaultIndex("FlightDetails");

        }
        public List<FlightDetails> GetResult()
        {
            //if (client.IndexExists("FlightDetails").Exists)
            {
                var response = client.Search<FlightDetails>();
                return response.Documents.ToList();
            }
            return null;
        }

        public List<FlightDetails> GetResult(string condition)
        {
            if (client.IndexExists("FlightDetails").Exists)
            {
                var query = condition;

                return client.SearchAsync<FlightDetails>(s => s
                .From(0)
                .Take(10)
                .Query(qry => qry
                    .Bool(b => b
                        .Must(m => m
                            .QueryString(qs => qs
                                .DefaultField("_all")
                                .Query(query)))))).Result.Documents.ToList();
            }
            return null;
        }

        public void AddNewIndex(FlightDetails data)
        {
            client.IndexAsync<FlightDetails>(data, null);
        }
    }
}