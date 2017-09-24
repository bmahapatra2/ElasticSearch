using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight
{
    public class FlightDetails
    {
        public int ID
        {
            get;
            set;
        }
        public string FlightName
        {
            get;
            set;
        }
        
        public string FlightDestination
        {
            get;
            set;
        }

        public FlightDetails()
        {

        }
        public FlightDetails(int id, string flightName, string flightDestination)
        {
            this.ID = id;
            this.FlightName = flightName;
            this.FlightDestination = flightDestination;
        }
    }
}

      
