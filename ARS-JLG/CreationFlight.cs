using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_JLG
{
    public class CreationFlight : IFlightInformation
    {
        public CreationFlight()
        {

        }

        public string AirlineCode { get; set; }
        public int FlightNumber { get; set; }
        public string ArrivalStation { get; set; }
        public string DepartureStation { get; set; }
        public DateTime? ScheduledTimeArrival { get; set; }
        public DateTime? ScheduledTimeDeparture { get; set; }

        /// <summary>
        /// Get initial information requirements and check if flight exists
        /// </summary>
        /// <returns> Status if information is not existing </returns>
        public bool GetInitialInformation()
        {
            var searchFlight = new SearchFlight();
            var getInput = new GetUserInput();
            var constMessage = new ConstantMessage();
            bool isFlightExists;

            // Get validated information
            AirlineCode = getInput.AskStringToUpper(constMessage.ASK_AIRLINE_CODE);
            FlightNumber = getInput.AskNumber(constMessage.ASK_FLIGHT_NUMBER);
            ArrivalStation = getInput.AskStringToUpper(constMessage.ASK_ARRIVAL_STATION);
            DepartureStation = getInput.AskStringToUpper(constMessage.ASK_DEPARTURE_STATION);

            // Check if flight is existing
            isFlightExists = searchFlight.SearchFlightExistence(AirlineCode, FlightNumber, ArrivalStation, DepartureStation);

            return isFlightExists;
        }

        public void GetFinalInformation()
        {
            var getInput = new GetUserInput();
            var constMessage = new ConstantMessage();

            ScheduledTimeArrival = getInput.AskTime(constMessage.ASK_SCHEDULE_TIME_ARRIVAL);
            ScheduledTimeDeparture = getInput.AskTime(constMessage.ASK_SCHEDULE_TIME_DEPARTURE);
        }

        public bool CreateFlight()
        {
            var repositoryCollection = new RepositoryCollection();
            var isFlightCreated = false;
            bool isValid;

            var x = typeof(Flight).GetProperties();

            // Create Flight
            var newFlight = new Flight(AirlineCode, FlightNumber, ArrivalStation, DepartureStation, ScheduledTimeArrival, ScheduledTimeDeparture, out isValid);
            // Check if created flight is valid
            if (isValid)
            {
                repositoryCollection.AddRecord(newFlight);
                isFlightCreated = true;
            }

            return isFlightCreated;
        }
    }
}
