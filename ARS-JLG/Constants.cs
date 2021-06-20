using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_JLG
{
    public class Constants
    {
        public Constants()
        {
            MAIN_INTERFACE = 0;
            FLIGHT_MAINTENANCE_INTERFACE = 1;
            ADD_FLIGHT_INTERFACE = 2;
            SEARCH_FLIGHT_INTERFACE = 10;
            SEARCH_FLIGHT_BY_AIRLINE_CODE = 11;
            SEARCH_FLIGHT_BY_FLIGHT_NUMBER = 12;
            SEARCH_FLIGHT_BY_STATION = 13;
            DISPLAY_ALL_FLIGHTS_INTERFACE = 14;
            RESERVATION_INTERFACE = 20;
            CREATE_RESERVATION_INTERFACE = 21;
            DISPLAY_ALL_RESERVATION_INTERFACE = 22;
            SEARCH_RESERVATION_BY_PNR_NUMBER = 23;
        }

        //UI Screen
        public readonly int MAIN_INTERFACE;
        public readonly int FLIGHT_MAINTENANCE_INTERFACE;
        public readonly int SEARCH_FLIGHT_INTERFACE;
        public readonly int ADD_FLIGHT_INTERFACE;
        public readonly int RESERVATION_INTERFACE;
        public readonly int DISPLAY_ALL_FLIGHTS_INTERFACE;
        public readonly int CREATE_RESERVATION_INTERFACE;
        public readonly int DISPLAY_ALL_RESERVATION_INTERFACE;

        //Search reservation
        public readonly int SEARCH_RESERVATION_BY_PNR_NUMBER;

        //Search flight options
        public readonly int SEARCH_FLIGHT_BY_AIRLINE_CODE;
        public readonly int SEARCH_FLIGHT_BY_FLIGHT_NUMBER;
        public readonly int SEARCH_FLIGHT_BY_STATION;
        
    }
}
