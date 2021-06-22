using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_JLG
{
    public class Reservation : IFlightInformation
    {
        public Reservation()
        {
            AirlineCode = null;
            FlightNumber = 0;
            ArrivalStation = null;
            DepartureStation = null;
            ScheduledTimeArrival = null;
            ScheduledTimeDeparture = null;
            NumberOfPassengers = 0;
            FlightDate = DateTime.MinValue;
            PassengerList = null;
        }

        /// <summary>
        /// Validate Reservation Information
        /// </summary>
        /// <param name="flight"></param>
        /// <param name="flightDate"></param>
        /// <param name="numberOfPassengers"></param>
        /// <param name="passengerList"></param>
        /// <param name="isInformationValid"></param>
        public Reservation(DateTime flightDate, int numberOfPassengers, out bool isInformationValid)
        {

            isInformationValid = ValidateReservationInformation(flightDate, numberOfPassengers);

            if (isInformationValid)
            {
                FlightDate = flightDate;
                NumberOfPassengers = numberOfPassengers;
            }

        }

        public string AirlineCode { get; set; }
        public int FlightNumber { get; set; }
        public string ArrivalStation { get; set; }
        public string DepartureStation { get; set; }
        public DateTime? ScheduledTimeArrival { get; set; }
        public DateTime? ScheduledTimeDeparture { get; set; }
        public int NumberOfPassengers { get; set; }
        public DateTime FlightDate { get; set; }
        public List<Passenger> PassengerList { get; set; }

        private bool ValidateReservationInformation(DateTime flightDate, int numberOfPassengers)
        {
            var errorMessage = new ConstantMessage();
            var isValid = true;

            if (!ValidateFlightDateValue(flightDate)) errorMessage.DisplayErrorMessage(errorMessage.ERR_MSG_FLIGHT_DATE, out isValid);
            if (!ValidateNumberOfPassengers(numberOfPassengers)) errorMessage.DisplayErrorMessage(errorMessage.ERR_MSG_NUMBER_OF_PASSENGERS, out isValid);

            return isValid;
        }

        private bool ValidateFlightDateValue(DateTime flightDate)
        {
            var isValid = true;

            if (flightDate < DateTime.Now.Date) isValid = false;

            return isValid;
        }

        private bool ValidateNumberOfPassengers(int numberOfPassengers)
        {
            var isValid = false;

            if (numberOfPassengers >= 1 && numberOfPassengers <= 5) isValid = true;

            return isValid;
        }

        private bool ValidateListOfPassengers(List<Passenger> passengerList, int numberOfPassengers)
        {
            var isValid = false;

            if (passengerList.Count == numberOfPassengers) isValid = true;

            return isValid;
        }
    }
}
