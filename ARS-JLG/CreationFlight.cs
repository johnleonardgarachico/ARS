using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_JLG
{
    public class CreationFlight : IFlights
    {
        public CreationFlight()
        {

        }

        public string AirlineCode { get; set; }
        public int FlightNumber { get; set; }
        public string ArrivalStation { get; set; }
        public string DepartureStation { get; set; }
        public DateTime ScheduledTimeArrival { get; set; }
        public DateTime ScheduledTimeDeparture { get; set; }

        public bool CreateFlight()
        {

            var isFlightExists = true;
            var isFlightCreated = false;
            var flightCollections = new RepositoryFlightCollection();
            var infoValidation = new ValidateFlightInformation();

            // Get validated information
            AirlineCode = infoValidation.GetAirlineCode();
            FlightNumber = infoValidation.GetFlightNumber();
            ArrivalStation = infoValidation.GetStation("Arrival Station");
            DepartureStation = infoValidation.GetStation("Departure Station");

            // Check if flight is existing
            isFlightExists = flightCollections.CheckFlightExistence(AirlineCode, FlightNumber, ArrivalStation, DepartureStation);

            if (!isFlightExists)
            {
                // Get the STA and STD
                ScheduledTimeArrival = infoValidation.GetTimeSchedule("Scheduled Time Arrival");
                ScheduledTimeDeparture = infoValidation.GetTimeSchedule("Scheduled TimeDeparture");
                // Create the flight
                flightCollections.AddFlight(this);
                // Notify that flight is created
                isFlightCreated = true;
            }

            return isFlightCreated;
        }
    }
}
