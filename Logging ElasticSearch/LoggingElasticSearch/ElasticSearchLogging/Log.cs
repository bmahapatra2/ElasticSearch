using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LoggingElasticSearch
{
    public class Log
    {
        public string Status { get; private set; }
        public string IpAddress { get; private set; }
        public string SessionId { get; private set; }
        public DateTime RequestTime { get; private set; }
        public DateTime ResponseTime { get; private set; }

       
        public Log(string status, string ipAddress, string sessionId, DateTime requestTime, DateTime responseTime)
        {
            Status = status;
            IpAddress = ipAddress;
            SessionId = sessionId;
            RequestTime = requestTime;
            ResponseTime = responseTime;
        }

    }
}


