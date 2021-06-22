using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_JLG
{
    public class ConstantMessage
    {
        public ConstantMessage()
        {
            // Error Messages
            ERR_MSG_AIRLINE_CODE = " Error: Invalid Airline Code!";
            ERR_MSG_FLIGHT_NUMBER = " Error: Invalid Flight Number!";
            ERR_MSG_ARRIVAL_STATION = " Error: Invalid Arrival Station!";
            ERR_MSG_DEPARTURE_STATION = " Error: Invalid Departure Station!";
            ERR_MSG_FLIGHT_DATE = " Error: Invalid Flight Date!";
            ERR_MSG_NUMBER_OF_PASSENGERS = " Error: Invalid Number of Passengers!";
            ERR_MSG_FIRST_NAME = " Error: Invalid First Name!";
            ERR_MSG_LAST_NAME = " Error: Invalid Last Name!";
            ERR_MSG_BIRTH_DATE = " Error: Invalid Birth Date!";
            ERR_MSG_SCHEDULED_TIME_ARRIVAL = " Error: Invalid Time Arrival";
            ERR_MSG_SCHEDULED_TIME_DEPARTURE = " Error: Invalid Time Departure";
            // Input Messages
            ASK_AIRLINE_CODE = " Enter Airline Code: ";
            ASK_FLIGHT_NUMBER = " Enter Flight Number: ";
            ASK_ARRIVAL_STATION = " Enter Arrival Station: ";
            ASK_DEPARTURE_STATION = " Enter Departure Station: ";
            ASK_SCHEDULE_TIME_ARRIVAL = " Enter Scheduled Time Arrival: ";
            ASK_SCHEDULE_TIME_DEPARTURE = " Enter Scheduled Time Departure: ";
            ASK_FLIGHT_DATE = " Enter Flight Date: ";
            ASK_NUMBER_OF_PASSENGERS = " Enter Number of Passengers: ";
            ASK_FIRST_NAME = " Enter First Name: ";
            ASK_LAST_NAME = " Enter Last Name: ";
            ASK_BIRTH_DATE = " Enter Birth Date: ";
    }

        // Flight information error input message
        public readonly string ERR_MSG_AIRLINE_CODE;
        public readonly string ERR_MSG_FLIGHT_NUMBER;
        public readonly string ERR_MSG_ARRIVAL_STATION;
        public readonly string ERR_MSG_DEPARTURE_STATION;
        public readonly string ERR_MSG_SCHEDULED_TIME_ARRIVAL;
        public readonly string ERR_MSG_SCHEDULED_TIME_DEPARTURE;
        // Reservation information error input message
        public readonly string ERR_MSG_FLIGHT_DATE;
        public readonly string ERR_MSG_NUMBER_OF_PASSENGERS;
        // Passenger information error input message
        public readonly string ERR_MSG_FIRST_NAME;
        public readonly string ERR_MSG_LAST_NAME;
        public readonly string ERR_MSG_BIRTH_DATE;

        // Ask Input Message
        public readonly string ASK_AIRLINE_CODE;
        public readonly string ASK_FLIGHT_NUMBER;
        public readonly string ASK_ARRIVAL_STATION;
        public readonly string ASK_DEPARTURE_STATION;
        public readonly string ASK_SCHEDULE_TIME_ARRIVAL;
        public readonly string ASK_SCHEDULE_TIME_DEPARTURE;
        public readonly string ASK_FLIGHT_DATE;
        public readonly string ASK_NUMBER_OF_PASSENGERS;
        public readonly string ASK_FIRST_NAME;
        public readonly string ASK_LAST_NAME;
        public readonly string ASK_BIRTH_DATE;

        /// <summary>
        /// Display error message and pass false value
        /// </summary>
        /// <param name="message"></param>
        /// <param name="isError"></param>
        public void DisplayErrorMessage(string message, out bool isError)
        {
            Console.WriteLine(message);
            isError = false;
        }
    }
}
