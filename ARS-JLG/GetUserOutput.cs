using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_JLG
{
    public class GetUserOutput
    {
        public GetUserOutput()
        {

        }

        /// <summary>
        /// Display given list of flights
        /// </summary>
        /// <param name="listOfFlights"></param>
        public void DisplayFlights(List<IFlightInformation> listOfFlights)
        {
            Console.WriteLine("{0,25}{1,25}{2,20}{3,15}{4,15}", "Airline Code", "Flight Number", "Station", "STA", "STD");

            foreach (var flight in listOfFlights)
            {
                Console.WriteLine("{0,25}{1,25}{2,20}{3,15}{4,15}",
                    flight.AirlineCode,
                    flight.FlightNumber,
                    flight.ArrivalStation + " - " + flight.DepartureStation,
                    flight.ScheduledTimeArrival?.ToString("HH:mm"),
                    flight.ScheduledTimeDeparture?.ToString("HH:mm"));
            }
        }

        public void DisplayCurrentReservation(Reservation reservation)
        {
            Console.WriteLine("-------------------------------Confirm Reservation---------------------------\n");

            Console.WriteLine("{0,30}{1,30}{2,20}{3,10}{4,25}{5,20}{6,15}{7,20}{8,10}{9,10}",
            "First Name", "Last Name",
            "Birth Date", "Age", "Airline Code",
            "Flight Number", "Station", "Flight Date",
            "STA", "STD");

            // Display each passenger information
            foreach (var passenger in reservation.PassengerList)
            {
                Console.WriteLine("{0,30}{1,30}{2,20}{3,10}{4,25}{5,20}{6,15}{7,20}{8,10}{9,10}",
                    passenger.FirstName,
                    passenger.LastName,
                    passenger.BirthDate.ToString("MM/dd/yyyy"),
                    passenger.Age,
                    reservation.AirlineCode,
                    reservation.FlightNumber,
                    reservation.ArrivalStation + " - " + reservation.DepartureStation,
                    reservation.FlightDate.ToString("MM/dd/yyyy"),
                    reservation.ScheduledTimeArrival?.ToString("HH:mm"),
                    reservation.ScheduledTimeDeparture?.ToString("HH:mm"));
            }

            Console.WriteLine("-----------------------------------------------------------------------------\n");
        }

        public void DisplayReservationHeader()
        {
            Console.WriteLine("{0,10}{1,30}{2,30}{3,20}{4,10}{5,25}{6,20}{7,15}{8,20}{9,10}{10,10}",
                "PNR Number", "First Name", "Last Name",
                "Birth Date", "Age", "Airline Code",
                "Flight Number", "Station", "Flight Date",
                "STA", "STD");
        }

        public void DisplayReservation(string pnr, Reservation reservation)
        {
            // Display each passenger information
            foreach (var passenger in reservation.PassengerList)
            {
                Console.WriteLine("{0,10}{1,30}{2,30}{3,20}{4,10}{5,25}{6,20}{7,15}{8,20}{9,10}{10,10}",
                    pnr,
                    passenger.FirstName,
                    passenger.LastName,
                    passenger.BirthDate.ToString("MM/dd/yyyy"),
                    passenger.Age,
                    reservation.AirlineCode,
                    reservation.FlightNumber,
                    reservation.ArrivalStation + " - " + reservation.DepartureStation,
                    reservation.FlightDate.ToString("MM/dd/yyyy"),
                    reservation.ScheduledTimeArrival?.ToString("HH:mm"),
                    reservation.ScheduledTimeDeparture?.ToString("HH:mm"));
            }
        }
    }
}
