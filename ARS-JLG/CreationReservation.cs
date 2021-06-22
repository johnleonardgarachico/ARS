using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_JLG
{
    public class CreationReservation
    {
        public CreationReservation()
        {
            reservation = new Reservation();
            isReservationConfirmed = false;
        }

        private delegate bool ConfirmReservationCompleted();
        private bool isReservationConfirmed;
        public Reservation reservation;

        public bool GetInitialInformation(out List<IFlightInformation> flightList)
        {
            var getInput = new GetUserInput();
            var searchFlight = new SearchFlight();
            var constMessage = new ConstantMessage();
            bool hasFlight;

            reservation.AirlineCode = getInput.AskStringToUpper(constMessage.ASK_AIRLINE_CODE);
            reservation.FlightNumber = getInput.AskNumber(constMessage.ASK_FLIGHT_NUMBER);

            hasFlight = searchFlight.TrySearchForFlight(reservation.AirlineCode, reservation.FlightNumber, out flightList);

            return hasFlight;
        }

        public bool GetSecondaryInformation()
        {
            var getInput = new GetUserInput();
            var searchFlight = new SearchFlight();
            var constMessage = new ConstantMessage();
            bool hasFlight;
            IFlightInformation flightInfo;

            reservation.ArrivalStation = getInput.AskStringToUpper(constMessage.ASK_ARRIVAL_STATION);
            reservation.DepartureStation = getInput.AskStringToUpper(constMessage.ASK_DEPARTURE_STATION);

            hasFlight = searchFlight.TrySearchForFlight(reservation.AirlineCode, reservation.FlightNumber, 
                reservation.ArrivalStation, reservation.DepartureStation, out flightInfo);

            if (hasFlight)
            {
                reservation.ScheduledTimeArrival = flightInfo.ScheduledTimeArrival;
                reservation.ScheduledTimeDeparture = flightInfo.ScheduledTimeDeparture;
            }

            return hasFlight;
        }

        public bool GetFinalInformation()
        {
            var getInput = new GetUserInput();
            var constMessage = new ConstantMessage();
            bool isValid;

            reservation.FlightDate = getInput.AskDate(constMessage.ASK_FLIGHT_DATE);
            reservation.NumberOfPassengers = getInput.AskNumber(constMessage.ASK_NUMBER_OF_PASSENGERS);

            var validateInfo = new Reservation(reservation.FlightDate, reservation.NumberOfPassengers, out isValid);

            return isValid;
        }

        /// <summary>
        /// Get all other required information and ask user to confirm reservation
        /// </summary>
        /// <returns> Status if reservation is confirmed </returns>
        public void GetPassengersInformation(int numberOfPassengers)
        {
            var getInput = new GetUserInput();
            Passenger passenger = new Passenger();
            var constMessage = new ConstantMessage();
            bool isValid;
            reservation.PassengerList = new List<Passenger>();

            for (int i = 0; i < numberOfPassengers; i++)
            {
                // Collect Required Information
                passenger.FirstName = getInput.AskStringValue(constMessage.ASK_FIRST_NAME);
                passenger.LastName = getInput.AskStringValue(constMessage.ASK_LAST_NAME);
                passenger.BirthDate = getInput.AskDate(constMessage.ASK_BIRTH_DATE);
                // Validate Information
                var validatedPassenger = new Passenger(passenger.FirstName, passenger.LastName, passenger.BirthDate, out isValid);

                if (isValid)
                {
                    reservation.PassengerList.Add(validatedPassenger);
                }
                else
                {
                    i--;
                }
            }
        }

        /// <summary>
        /// Check if all required information has been filled and add reservation on the record
        /// </summary>
        /// <param name="isConfirmed"></param>
        /// <returns> Status is reservation is created successfully </returns>
        public bool CreateReservation()
        {
            var repositoryCollection = new RepositoryCollection();
            var checkInfo = new Reservation();
            var isCreated = false;
            string passengerNameRecord;

            // Check if all required information has been filled up
            if (isReservationConfirmed && reservation.AirlineCode != checkInfo.AirlineCode && 
                reservation.ArrivalStation != checkInfo.ArrivalStation && 
                reservation.DepartureStation != checkInfo.DepartureStation && 
                reservation.ScheduledTimeArrival != checkInfo.ScheduledTimeArrival &&
                reservation.PassengerList != checkInfo.PassengerList && 
                reservation.ScheduledTimeDeparture != checkInfo.ScheduledTimeDeparture &&
                reservation.FlightDate != checkInfo.FlightDate && reservation.FlightNumber != checkInfo.FlightNumber &&
                reservation.NumberOfPassengers != checkInfo.NumberOfPassengers)
            {
                // Generate PNR Number
                passengerNameRecord = repositoryCollection.GeneratePNR();
                // Add the reservation on database
                repositoryCollection.AddRecord(passengerNameRecord, reservation);
                isCreated = true;
            }

            return isCreated;
        }

        public bool ConfirmReservation()
        {
            bool isAccepted;

            Console.WriteLine(" Confirm Reservation? (Y/N): ");
            var consoleInput = Console.ReadLine().ToUpper().Trim();

            switch (consoleInput)
            {
                case "Y":
                    isAccepted = true;
                    break;

                case "N":
                    isAccepted = false;
                    break;

                default:
                    Console.WriteLine(" Error: Invalid input! Choose between (Y/N)");
                    isAccepted = ConfirmReservation(ConfirmReservation);
                    break;
            }

            isReservationConfirmed = isAccepted;
            return isAccepted;
        }

        private bool ConfirmReservation(ConfirmReservationCompleted confirmReservation)
        {
            return confirmReservation();
        }
    }
}
