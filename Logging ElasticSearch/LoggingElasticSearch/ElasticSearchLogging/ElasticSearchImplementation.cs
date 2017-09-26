

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace LoggingElasticSearch
{
    public class ElasticSearchImplementation
    {
        ElasticClient client = null;
        public ElasticSearchImplementation()
        {
            var uri = new Uri("http://172.16.14.49:9200/");
            var settings = new ConnectionSettings(uri);
            client = new ElasticClient(settings);
            settings.DefaultIndex("log");
            client.Index("log");
        }


        public List<Log> GetResult()
        {
            if (client.IndexExists("log").Exists)
            {
                var response = client.Search<Log>();
                return response.Documents.ToList();
            }
            return null;
        }

        public List<Log> GetResult(string condition)
        {
            if (client.IndexExists("log").Exists)
            {
                var query = condition;

                return client.SearchAsync<Log>(s => s
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

        public void AddNewIndex(Log data)
        {
            client.IndexAsync<Log>(data, null);
        }
    }
}