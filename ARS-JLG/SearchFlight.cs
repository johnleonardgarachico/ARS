using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_JLG
{
    public class SearchFlight
    {
        public SearchFlight()
        {

        }

        // Collections repository access
        RepositoryCollection repositoryCollection = new RepositoryCollection();

        /// <summary>
        /// Search Flight by Airline Code
        /// </summary>
        /// <param name="airlineCode"></param>
        /// <returns> List of Flights </returns>
        public bool TrySearchForFlight(string airlineCode, out List<IFlightInformation> flightInfo)
        {
            var isExists = false;

            flightInfo = repositoryCollection.GetAllFlights().Where(x => x.AirlineCode.Equals(airlineCode)).ToList();

            if (flightInfo.Count != 0) isExists = true;

            return isExists;
        }

        /// <summary>
        /// Search Flight by Flight number
        /// </summary>
        /// <param name="flightNumber"></param>
        /// <returns> List of Flight </returns>
        public bool TrySearchForFlight(int flightNumber, out List<IFlightInformation> flightInfo)
        {
            var isExists = false;

            flightInfo = repositoryCollection.GetAllFlights().Where(x => x.FlightNumber.Equals(flightNumber)).ToList();

            if (flightInfo.Count != 0) isExists = true;

            return isExists;
        }

        /// <summary>
        /// Search Flight by Airline Code and Flight Number
        /// </summary>
        /// <param name="airlineCode"></param>
        /// <param name="flightNumber"></param>
        /// <returns> List of Flight </returns>
        public bool TrySearchForFlight(string airlineCode, int flightNumber, out List<IFlightInformation> flightInfo)
        {
            var isExists = false;

            flightInfo = repositoryCollection.GetAllFlights().Where(x => (x.FlightNumber.Equals(flightNumber) &&
                x.AirlineCode.Equals(airlineCode))).ToList();

            if (flightInfo.Count != 0) isExists = true;

            return isExists;
        }

        /// <summary>
        /// Search Flight By Station
        /// </summary>
        /// <param name="arrivalStation"></param>
        /// <param name="departureStation"></param>
        /// <returns> List of Flight </returns>
        public bool TrySearchForFlight(string arrivalStation, string departureStation, out List<IFlightInformation> flightInfo)
        {
            var isExists = false;
            string expectedInformation = arrivalStation + departureStation;

            flightInfo = repositoryCollection.GetAllFlights().Where(x => (x.ArrivalStation + x.DepartureStation).
                Equals(expectedInformation)).ToList();

            if (flightInfo.Count != 0) isExists = true;

            return isExists;
        }

        /// <summary>
        /// Search Flight By Airline Code, Flight Number, Arrival Station, and Departure Station
        /// </summary>
        /// <param name="airlineCode"></param>
        /// <param name="flightNumber"></param>
        /// <param name="arrivalStation"></param>
        /// <param name="departureStation"></param>
        /// <param name="flightInfo"></param>
        /// <returns> Status if flight exists </returns>
        public bool TrySearchForFlight(string airlineCode, int flightNumber, string arrivalStation, string departureStation, out IFlightInformation flightInfo)
        {
            string expectedInformation = airlineCode + flightNumber.ToString() + arrivalStation + departureStation;
            var isExists = false;
            flightInfo = null;

            var flightList = repositoryCollection.GetAllFlights().Where(x => (x.AirlineCode + x.FlightNumber.ToString() +
            x.ArrivalStation + x.DepartureStation).Equals(expectedInformation)).ToList();

            if (flightList.Count == 1)
            {
                flightInfo = flightList.First();
                isExists = true;
            }

            return isExists;
        }

        public bool SearchFlightExistence(string airlineCode, int flightNumber, string arrivalStation, string departureStation)
        {
            var repositoryCollection = new RepositoryCollection();
            var flightList = repositoryCollection.GetAllFlights();

            return repositoryCollection.GetAllFlights().Any(x => (x.AirlineCode + x.FlightNumber.ToString() +
                x.ArrivalStation + x.DepartureStation).Equals(airlineCode + flightNumber.ToString() + arrivalStation +
                departureStation));
        }
    }
}
