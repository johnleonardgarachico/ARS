using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_JLG
{
    public class RepositoryFlightCollection
    {
        public RepositoryFlightCollection()
        {

        }

        /// <summary>
        /// Add a flight on the list
        /// </summary>
        /// <param name="flight"></param>
        public void AddFlight(IFlights flight)
        {
            DataBaseCollection.AvailableFlightsList.Add(flight);
        }

        /// <summary>
        /// Get all available flights
        /// </summary>
        /// <returns>List of available flights</returns>
        public List<IFlights> GetAllFlights()
        {
            return DataBaseCollection.AvailableFlightsList;
        }

        /// <summary>
        /// Search Flight by Airline Code
        /// </summary>
        /// <param name="airlineCode"></param>
        /// <returns> List of Flights </returns>
        public List<IFlights> SearchFlight(string airlineCode)
        {
            return DataBaseCollection.AvailableFlightsList.Where(x => x.AirlineCode.Equals(airlineCode)).ToList();
        }

        /// <summary>
        /// Search Flight by Flight number
        /// </summary>
        /// <param name="flightNumber"></param>
        /// <returns> List of Flight </returns>
        public List<IFlights> SearchFlight(int flightNumber)
        {
            return DataBaseCollection.AvailableFlightsList.Where(x => x.FlightNumber.Equals(flightNumber)).ToList();
        }

        /// <summary>
        /// Search Flight by Airline Code and Flight Number
        /// </summary>
        /// <param name="airlineCode"></param>
        /// <param name="flightNumber"></param>
        /// <returns> List of Flight </returns>
        public List<IFlights> SearchFlight(string airlineCode, int flightNumber)
        {
            return DataBaseCollection.AvailableFlightsList.Where(x => (x.FlightNumber.Equals(flightNumber) &&
                x.AirlineCode.Equals(airlineCode))).ToList();
        }

        /// <summary>
        /// Search Flight By Station
        /// </summary>
        /// <param name="arrivalStation"></param>
        /// <param name="departureStation"></param>
        /// <returns> List of Flight </returns>
        public List<IFlights> SearchFlight(string arrivalStation, string departureStation)
        {
            return DataBaseCollection.AvailableFlightsList.Where(x => (x.ArrivalStation + x.DepartureStation).
                Equals(arrivalStation + departureStation)).ToList();
        }

        /// <summary>
        /// Check if flight existing
        /// </summary>
        /// <param name="airlineCode"></param>
        /// <param name="flightNumber"></param>
        /// <param name="arrivalStation"></param>
        /// <param name="departureStation"></param>
        /// <returns>Status if flight existing</returns>
        public bool CheckFlightExistence(string airlineCode, int flightNumber, string arrivalStation, string departureStation)
        {
            return DataBaseCollection.AvailableFlightsList.Any(x => (x.AirlineCode + x.FlightNumber.ToString() +
                x.ArrivalStation + x.DepartureStation).Equals(airlineCode + flightNumber.ToString() + arrivalStation +
                departureStation));
        }

        /// <summary>
        /// Check if a flight existing and gives some data of the existing flight
        /// </summary>
        /// <param name="airlineCode"></param>
        /// <param name="flightNumber"></param>
        /// <param name="arrivalStation"></param>
        /// <param name="departureStation"></param>
        /// <param name="scheduledTimeArrival"></param>
        /// <param name="scheduledTimeDeparture"></param>
        /// <returns> Status if flight exists</returns>
        public bool CheckFlightExistence(string airlineCode, int flightNumber, string arrivalStation, string departureStation,
            out DateTime scheduledTimeArrival, out DateTime scheduledTimeDeparture)
        {
            var isExists = false;
            IFlights flightInformation;
            scheduledTimeArrival = DateTime.MinValue;
            scheduledTimeDeparture = DateTime.MinValue;

            flightInformation = DataBaseCollection.AvailableFlightsList.Find(x => (x.AirlineCode + x.FlightNumber.ToString() +
                x.ArrivalStation + x.DepartureStation).Equals(airlineCode + flightNumber.ToString() + arrivalStation +
                departureStation));

            if (flightInformation != null)
            {
                scheduledTimeArrival = flightInformation.ScheduledTimeArrival;
                scheduledTimeDeparture = flightInformation.ScheduledTimeDeparture;
                isExists = true;
            }
            else
            {
                isExists = false;
            }

            return isExists;
        }
    }
}
