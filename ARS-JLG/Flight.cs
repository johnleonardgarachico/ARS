using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ARS_JLG
{
    public class Flight : IFlightInformation
    {
        public Flight()
        {
            AirlineCode = null;
            FlightNumber = 0;
            ArrivalStation = null;
            DepartureStation = null;
            ScheduledTimeArrival = null;
            ScheduledTimeDeparture = null;
        }

        /// <summary>
        /// Validate Flight Information
        /// </summary>
        /// <param name="airlineCode"></param>
        /// <param name="flightNumber"></param>
        /// <param name="arrivalStation"></param>
        /// <param name="departureStation"></param>
        /// <param name="scheduledTimeArrival"></param>
        /// <param name="scheduledTimeDeparture"></param>
        /// <param name="isInformationValid"></param>
        public Flight(string airlineCode, int flightNumber, string arrivalStation, string departureStation,
            DateTime? scheduledTimeArrival, DateTime? scheduledTimeDeparture, out bool isInformationValid)
        {
            isInformationValid = ValidateFlightInformation(airlineCode, flightNumber, arrivalStation, departureStation,
                scheduledTimeArrival, scheduledTimeDeparture);

            if (isInformationValid)
            {
                AirlineCode = airlineCode;
                FlightNumber = flightNumber;
                ArrivalStation = arrivalStation;
                DepartureStation = departureStation;
                ScheduledTimeArrival = scheduledTimeArrival;
                ScheduledTimeDeparture = scheduledTimeDeparture;
            }
        }

        public string AirlineCode { get; set; }
        public int FlightNumber { get; set; }
        public string ArrivalStation { get; set; }
        public string DepartureStation { get; set; }
        public DateTime? ScheduledTimeArrival { get; set; }
        public DateTime? ScheduledTimeDeparture { get; set; }

        private bool ValidateFlightInformation(string airlineCode, int flightNumber, string arrivalStation,
            string departureStation, DateTime? scheduledTimeArrival, DateTime? scheduledTimeDeparture)
        {
            var errorMessage = new ConstantMessage();
            var isValid = true;

            if (!ValidateAirlineCode(airlineCode)) errorMessage.DisplayErrorMessage(errorMessage.ERR_MSG_AIRLINE_CODE, out isValid);
            if (!ValidateFlightNumberRange(flightNumber)) errorMessage.DisplayErrorMessage(errorMessage.ERR_MSG_FLIGHT_NUMBER, out isValid);
            if (!ValidateStation(arrivalStation)) errorMessage.DisplayErrorMessage(errorMessage.ERR_MSG_ARRIVAL_STATION, out isValid);
            if (!ValidateStation(departureStation)) errorMessage.DisplayErrorMessage(errorMessage.ERR_MSG_DEPARTURE_STATION, out isValid);
            if (!ValidateTimeInput(scheduledTimeArrival)) errorMessage.DisplayErrorMessage(errorMessage.ERR_MSG_SCHEDULED_TIME_ARRIVAL, out isValid);
            if (!ValidateTimeInput(scheduledTimeDeparture)) errorMessage.DisplayErrorMessage(errorMessage.ERR_MSG_SCHEDULED_TIME_DEPARTURE, out isValid);

            return isValid;
        }

        /// <summary>
        /// Check Airline Code Requirements
        /// </summary>
        /// <param name="airlineCode"></param>
        /// <returns> Status if the entered value is valid </returns>
        private bool ValidateAirlineCode(string airlineCode)
        {
            return Regex.IsMatch(airlineCode, @"^[A-Z][A-Z0-9]{1}$");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flightNumber"></param>
        /// <returns></returns>
        private bool ValidateFlightNumberRange(int flightNumber)
        {
            var isValid = false;

            if (flightNumber >= 1 && flightNumber <= 9999) isValid = true;

            return isValid;
        }

        /// <summary>
        /// Check Station Requirements
        /// </summary>
        /// <param name="station"></param>
        /// <returns></returns>
        private bool ValidateStation(string station)
        {
            return Regex.IsMatch(station, @"^[A-Z][A-Z0-9]{2}$");
        }

        /// <summary>
        /// Check if User entered a Time
        /// </summary>
        /// <param name="timeInput"></param>
        /// <returns></returns>
        private bool ValidateTimeInput(DateTime? timeInput)
        {
            var isValid = true;

            if (timeInput == null) isValid = false;

            return isValid;
        }
    }
}
