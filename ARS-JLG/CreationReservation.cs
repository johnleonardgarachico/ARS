using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_JLG
{
    public class CreationReservation : IReservation
    {
        public CreationReservation()
        {

        }

        public int NumberOfPassengers { get; set; }
        public DateTime FlightDate { get; set; }
        public List<Passenger> PassengerList { get; set; }
        public string AirlineCode { get; set; }
        public int FlightNumber { get; set; }
        public string ArrivalStation { get; set; }
        public string DepartureStation { get; set; }
        public DateTime ScheduledTimeArrival { get; set; }
        public DateTime ScheduledTimeDeparture { get; set; }

        public void AddReservation()
        {
            var reserveInformation = new ValidateReservationInformation();
            var passengerInformation = new ValidatePassengerInformation();
            var databaseAccess = new RepositoryReservationCollection();
            var hasFlight = false;
            string airlineCode;
            int flightNumber;
            string arrivalStation;
            string departureStation;
            string passengerNameRecord;
            DateTime scheduledTimeArrival;
            DateTime scheduledTimeDeparture;


            hasFlight = reserveInformation.CheckFlight(out airlineCode, out flightNumber);

            if (hasFlight)
            {
                // Get all necessary information for reservation
                reserveInformation.GetReservationStation(airlineCode, flightNumber, out arrivalStation, out departureStation,
                    out scheduledTimeArrival, out scheduledTimeDeparture);
                FlightDate = reserveInformation.GetFlightDate();
                NumberOfPassengers = reserveInformation.GetNumberOfPassengers();
                passengerNameRecord = databaseAccess.GeneratePNR();
                PassengerList = reserveInformation.GetPassengerInformation(NumberOfPassengers);
                // Gather all collected information
                AirlineCode = airlineCode;
                FlightNumber = flightNumber;
                ArrivalStation = arrivalStation;
                DepartureStation = departureStation;
                ScheduledTimeArrival = scheduledTimeArrival;
                ScheduledTimeDeparture = scheduledTimeDeparture;
                // Add the reservation on database
                databaseAccess.AddReservation(passengerNameRecord, this);
            }
            else
            {
                Console.WriteLine($" No flights for Airline Code: {airlineCode} and Flight Number: {flightNumber}");
            }
        }
    }
}
