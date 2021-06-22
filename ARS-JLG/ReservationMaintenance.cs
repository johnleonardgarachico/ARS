using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_JLG
{
    public class ReservationMaintenance
    {
        public ReservationMaintenance()
        {

        }

        public void CreateReservation()
        {
            var createReservation = new CreationReservation();
            var displayOutput = new GetUserOutput();
            bool isConfirmed;
            bool isFlightExists;
            bool isValid;
            List<IFlightInformation> flightList;

            // Get Airline Code and Flight Number
            isFlightExists = createReservation.GetInitialInformation(out flightList);
            // Check if Flight Exists
            if (isFlightExists)
            {
                // Display all avaiable flights for the selected flight
                displayOutput.DisplayFlights(flightList);
                // Get Arrival Station and Departure Station
                isFlightExists = createReservation.GetSecondaryInformation();
                // Check if flight exists for the selected station
                if (isFlightExists)
                {
                    // Get Flight Date and Number of Passengers
                    isValid = createReservation.GetFinalInformation();
                    // Check if entered flight date and number of passengers is valid
                    if (isValid)
                    {
                        // Get all the passengers information
                        createReservation.GetPassengersInformation(createReservation.reservation.NumberOfPassengers);
                        // Display the summary of the reservation
                        displayOutput.DisplayCurrentReservation(createReservation.reservation);
                        // Ask for reservation confirmation
                        isConfirmed = createReservation.ConfirmReservation();
                        // Check if the reservation is confirmed
                        if (isConfirmed)
                        {
                            // Create Reservation
                            isValid = createReservation.CreateReservation();
                            // Check if the reservation has been created
                            if (isValid)
                            {
                                Console.WriteLine("Reservation successfully created!");
                            }
                            else
                            {
                                Console.WriteLine("Please fill up all required information");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Reservation Cancelled!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Selected flight is not existing!");
                }
            }
            else
            {
                Console.WriteLine("Selected flight is not existing!");
            }
            
        }

        public void DisplayAllReservations()
        {
            var repositoryCollection = new RepositoryCollection();
            var displayOutput = new GetUserOutput();
            var reservationCollection = repositoryCollection.GetAllReservations();

            if (reservationCollection.Count != 0)
            {
                displayOutput.DisplayReservationHeader();

                foreach (var reservation in reservationCollection)
                {
                    displayOutput.DisplayReservation(reservation.Key, reservation.Value);
                }
            }
            else
            {
                Console.WriteLine("No reservation is existing in the record!");
            }
        }

        public void SearchReservation()
        {
            var searchReservation = new SearchReservation();
            var displayOutput = new GetUserOutput();
            var isExists = false;
            string consoleInput;
            Reservation reservation;

            Console.WriteLine("Enter PNR Number: ");
            consoleInput = Console.ReadLine();
            // Check if reservation is existing with the given PNR number
            isExists = searchReservation.SearchForReservation(consoleInput, out reservation);
            // Display reservation if existing
            if(isExists)
            {
                displayOutput.DisplayReservationHeader();
                displayOutput.DisplayReservation(consoleInput, reservation);
            }
            else
            {
                Console.WriteLine($" No such reservation with the given PNR Number:{consoleInput}");
            }
        }

    }
}
