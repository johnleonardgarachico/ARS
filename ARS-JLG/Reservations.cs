using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_JLG
{
    public class Reservations
    {
        public Reservations()
        {

        }

        public void CreateReservation()
        {
            var createReservation = new CreationReservation();
            createReservation.AddReservation();
        }

        public void DisplayAllReservations()
        {
            var reservationCollection = new RepositoryReservationCollection();
            var reservationsList = reservationCollection.GetAllReservations();

            Console.WriteLine("{0,10}{1,30}{2,30}{3,20}{4,10}{5,25}{6,20}{7,15}{8,20}{9,10}{10,10}",
                "PNR Number", "First Name", "Last Name", 
                "Birth Date", "Age", "Airline Code", 
                "Flight Number", "Station", "Flight Date",
                "STA", "STD");

            foreach (var reservation in reservationsList)
            {
                // Display each passengers information
                foreach (var passenger in reservation.Value.PassengerList)
                {
                    Console.WriteLine("{0,10}{1,30}{2,30}{3,20}{4,10}{5,25}{6,20}{7,15}{8,20}{9,10}{10,10}",
                        reservation.Key,
                        passenger.FirstName,
                        passenger.LastName,
                        passenger.BirthDate.ToString("MM/dd/yyyy"),
                        passenger.Age,
                        reservation.Value.AirlineCode,
                        reservation.Value.FlightNumber,
                        reservation.Value.ArrivalStation + " - " + reservation.Value.DepartureStation,
                        reservation.Value.FlightDate.ToString("MM/dd/yyyy"),
                        reservation.Value.ScheduledTimeArrival.ToString("HH:mm"),
                        reservation.Value.ScheduledTimeDeparture.ToString("HH:mm"));
                    
                }
            }
        }

        public void SearchReservation()
        {
            IReservation reservation;
            var reservationRepository = new RepositoryReservationCollection();
            var isExists = false;
            string consoleInput;



            Console.WriteLine("Enter PNR Number: ");
            consoleInput = Console.ReadLine();
            // Check if reservation is existing with the given PNR number
            isExists = reservationRepository.SearchByPNR(consoleInput, out reservation);
            // Display reservation if existing
            if(isExists)
            {
                Console.WriteLine("{0,10}{1,30}{2,30}{3,20}{4,10}{5,25}{6,20}{7,15}{8,20}{9,10}{10,10}",
                "PNR Number", "First Name", "Last Name",
                "Birth Date", "Age", "Airline Code",
                "Flight Number", "Station", "Flight Date",
                "STA", "STD");

                // Display each passenger information
                foreach (var passenger in reservation.PassengerList)
                {
                    Console.WriteLine("{0,10}{1,30}{2,30}{3,20}{4,10}{5,25}{6,20}{7,15}{8,20}{9,10}{10,10}",
                        consoleInput,
                        passenger.FirstName,
                        passenger.LastName,
                        passenger.BirthDate.ToString("MM/dd/yyyy"),
                        passenger.Age,
                        reservation.AirlineCode,
                        reservation.FlightNumber,
                        reservation.ArrivalStation + " - " + reservation.DepartureStation,
                        reservation.FlightDate.ToString("MM/dd/yyyy"),
                        reservation.ScheduledTimeArrival.ToString("HH:mm"),
                        reservation.ScheduledTimeDeparture.ToString("HH:mm"));
                }
            }
            else
            {
                Console.WriteLine($" No such reservation with the given PNR Number:{consoleInput}");
            }
        }

    }
}
