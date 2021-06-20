using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_JLG
{
    public class FlightMaintenance
    {
        public FlightMaintenance()
        {

        }

        public void AddFlight()
        {
            var isCreated = false;
            var CreateFlight = new CreationFlight();

            isCreated = CreateFlight.CreateFlight();

            if (isCreated)
            {
                Console.WriteLine("Flight Successfully Added!");
            }
            else
            {
                Console.WriteLine("Flight is ALready Existing!");
            }
        }

        public void SearchFlight(int searchMethod)
        {
            var constantCollection = new Constants();
            var validateFlightInformation = new ValidateFlightInformation();
            var flightCollection = new RepositoryFlightCollection();
            var listOfFlights = new List<IFlights>();

            if (searchMethod == constantCollection.SEARCH_FLIGHT_BY_AIRLINE_CODE)
            {
                listOfFlights = flightCollection.SearchFlight(validateFlightInformation.GetAirlineCode());
            }
            else if (searchMethod == constantCollection.SEARCH_FLIGHT_BY_FLIGHT_NUMBER)
            {
                listOfFlights = flightCollection.SearchFlight(validateFlightInformation.GetFlightNumber());
            }
            else if (searchMethod == constantCollection.SEARCH_FLIGHT_BY_STATION)
            {
                listOfFlights = flightCollection.SearchFlight(validateFlightInformation.GetStation("Arrival Station"), 
                    validateFlightInformation.GetStation("Departure Station"));
            }
            else
            {
                //Invalid search method
            }
            PrintFlights(listOfFlights);
        }

        public void DisplayAllFlights()
        {
            var flightCollection = new RepositoryFlightCollection();
            var listOfFlights = flightCollection.GetAllFlights();
            PrintFlights(listOfFlights);
        }

        /// <summary>
        /// Display given list of flights
        /// </summary>
        /// <param name="listOfFlights"></param>
        public void PrintFlights(List<IFlights> listOfFlights)
        {
            Console.WriteLine("{0,25}{1,25}{2,20}{3,15}{4,15}", "Airline Code", "Flight Number", "Station", "STA", "STD");

            foreach (var flight in listOfFlights)
            {
                Console.WriteLine("{0,25}{1,25}{2,20}{3,15}{4,15}",
                    flight.AirlineCode,
                    flight.FlightNumber,
                    flight.ArrivalStation + " - " + flight.DepartureStation,
                    flight.ScheduledTimeArrival.ToString("HH:mm"),
                    flight.ScheduledTimeDeparture.ToString("HH:mm"));
            }
        }
    }
}
