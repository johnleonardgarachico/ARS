using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_JLG
{
    public class DataBaseCollection
    {
        // Collection of all Available Flights
        public static List<IFlights> AvailableFlightsList = new List<IFlights>();
        // Collection of all Reserved Flights
        public static Dictionary<string , IReservation> ReservationCollection = new Dictionary<string, IReservation>();
        // Last PNR Generated
        public static char[] PassengerNameRecord { get; set; }
    }
}
