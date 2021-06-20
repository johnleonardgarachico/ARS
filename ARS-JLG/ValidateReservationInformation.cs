using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_JLG
{
    public class ValidateReservationInformation
    {
        public ValidateReservationInformation()
        {

        }

        private delegate void GetReservationStationCompleted(string airlineCode, int flightNumber, out string arrivalStation,
            out string departureStation, out DateTime scheduledTimeArrival, out DateTime scheduledTimeDeparture);
        private delegate DateTime GetFlightDateCompleted();
        private delegate int GetNumberOfPassengersCompleted();

        public bool CheckFlight(out string airlineCode, out int flightNumber)
        {
            var hasFlight = false;
            var constantCollection = new Constants();
            var validateFlightInformation = new ValidateFlightInformation();
            var flightsCollection = new RepositoryFlightCollection();
            var flightDisplay = new FlightMaintenance();

            // Get Airline Code and Flight Number
            airlineCode = validateFlightInformation.GetAirlineCode();
            flightNumber = validateFlightInformation.GetFlightNumber();

            // Get availables flights with the given information
            var flightsList = flightsCollection.SearchFlight(airlineCode, flightNumber);
            // Display available flights if there is any
            if (flightsList.Count != 0)
            {
                flightDisplay.PrintFlights(flightsList);
                hasFlight = true;
            }

            return hasFlight;
        }

        public void GetReservationStation(string airlineCode, int flightNumber, out string arrivalStation,
            out string departureStation, out DateTime scheduledTimeArrival, out DateTime scheduledTimeDeparture)
        {
            var isExists = true;
            var constantCollection = new Constants();
            var validateFlightInformation = new ValidateFlightInformation();
            var flightsCollection = new RepositoryFlightCollection();

            // Get Origin and Destination station
            arrivalStation = validateFlightInformation.GetStation("Arrival Station");
            departureStation = validateFlightInformation.GetStation("Departure Station");

            //Check if given information is an existing flight
            isExists = flightsCollection.CheckFlightExistence(airlineCode, flightNumber, arrivalStation,
                departureStation, out scheduledTimeArrival, out scheduledTimeDeparture);
            //Re-enter information if not an existing flight
            if (!isExists)
            {
                Console.WriteLine(" Entered flight is not existing!");
                GetReservationStation(airlineCode, flightNumber, out arrivalStation, out departureStation,
                    out scheduledTimeArrival,out scheduledTimeDeparture, GetReservationStation);
            }
        }

        private void GetReservationStation(string airlineCode, int flightNumber, out string arrivalStation,
            out string departureStation, out DateTime scheduledTimeArrival, out DateTime scheduledTimeDeparture,
            GetReservationStationCompleted getReservationInformation)
        {
            getReservationInformation(airlineCode, flightNumber, out arrivalStation, out departureStation,
                out scheduledTimeArrival, out scheduledTimeDeparture);
        }

        public DateTime GetFlightDate()
        {
            var isValid = false;
            var consoleInput = "";
            DateTime reservationDate;
            var validDateFormats = new string[] { "M/d/yyyy", "M/dd/yyyy", "MM/d/yyyy", "MM/dd/yyyy" };

            // Get input for flight date
            Console.WriteLine(" Enter Flight Date (mm/dd/yyyy): ");
            consoleInput = Console.ReadLine();
            // Check if the entered date is in a valid format
            isValid = DateTime.TryParseExact(consoleInput, validDateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out reservationDate);
            // Re-enter date if it is invalid
            if (!isValid)
            {
                Console.WriteLine(" Error: Invalid Date Format! Please enter in this format (mm/dd/yyyy)");
                reservationDate = GetFlightDate(GetFlightDate);
            }
            // Check if reservation date is a past date
            if (reservationDate.Date < DateTime.Now.Date)
            {
                Console.WriteLine(" Error: Invalid Date! (Reservation date cannot be past date)");
                reservationDate = GetFlightDate(GetFlightDate);
            }

            return reservationDate;
        }

        private DateTime GetFlightDate(GetFlightDateCompleted getFlightDate)
        {
            return getFlightDate();
        }

        public int GetNumberOfPassengers()
        {
            var isValid = true;
            int numberOfPassengers;

            Console.WriteLine(" Enter Number of Passengers: ");
            isValid = int.TryParse(Console.ReadLine(), out numberOfPassengers);
            // Check if entered input is a number
            if (!isValid)
            {
                Console.WriteLine(" Error: Invalid input (Please enter a number)");
                numberOfPassengers = GetNumberOfPassengers(GetNumberOfPassengers);
            }
            //Check if entered number is within 1 ~ 5
            if (numberOfPassengers < 1 || numberOfPassengers > 5)
            {
                Console.WriteLine(" Error: Invalid number of passengers! (Passengers can only be 1 ~ 5)");
                numberOfPassengers = GetNumberOfPassengers(GetNumberOfPassengers);
            }

            return numberOfPassengers;
        }

        private int GetNumberOfPassengers(GetNumberOfPassengersCompleted getNumberOfPassengers)
        {
            return getNumberOfPassengers();
        }

        public List<Passenger> GetPassengerInformation(int numberOfPassengers)
        {
            var passengerInformation = new ValidatePassengerInformation();
            var passenger = new Passenger();
            var passengerList = new List<Passenger>();
            int age;

            // Get all the information of the given number of passengers
            for (int i = 0; i < numberOfPassengers; i++)
            {
                Console.WriteLine($"------------Enter Details of Passenger {i + 1} ----------");
                passenger.FirstName = passengerInformation.GetPassengerName("First Name");
                passenger.LastName = passengerInformation.GetPassengerName("Last Name");
                passenger.BirthDate = passengerInformation.GetBirthDate(out age);
                passenger.Age = age;
                passengerList.Add(passenger);
            }

            return passengerList;
        }
    }
}
