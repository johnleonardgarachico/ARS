using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_JLG
{
    public interface IFlightInformation
    {
        public string AirlineCode { get; set; }
        public int FlightNumber { get; set; }
        public string ArrivalStation { get; set; }
        public string DepartureStation { get; set; }
        public DateTime? ScheduledTimeArrival { get; set; }
        public DateTime? ScheduledTimeDeparture { get; set; }
    }
}
