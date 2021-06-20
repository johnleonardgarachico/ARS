using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_JLG
{
    public class UserInterface
    {
        public UserInterface()
        {
        }

        Constants constantCollection = new Constants();
        private int chooseWhatToDo = 0;

        public void StartApp()
        {
            bool flag = true;

            while (flag)
            {
                switch (chooseWhatToDo)
                {
                    case var value when value == constantCollection.MAIN_INTERFACE:
                        MainScreen();
                        break;

                    case var value when value == constantCollection.FLIGHT_MAINTENANCE_INTERFACE:
                        FlightMaintenanceSelected();
                        break;

                    case var value when value == constantCollection.SEARCH_FLIGHT_INTERFACE:
                        SearchFlightSelected();
                        break;

                    case var value when value == constantCollection.ADD_FLIGHT_INTERFACE:
                        AddFlightSelected();
                        break;

                    case var value when value == constantCollection.SEARCH_FLIGHT_BY_AIRLINE_CODE:
                        SearchFlightByAirlineCodeSelected();
                        break;

                    case var value when value == constantCollection.SEARCH_FLIGHT_BY_FLIGHT_NUMBER:
                        SearchFlightByFlightNumberSelected();
                        break;

                    case var value when value == constantCollection.SEARCH_FLIGHT_BY_STATION:
                        SearchFlightByStationSelected();
                        break;

                    case var value when value == constantCollection.DISPLAY_ALL_FLIGHTS_INTERFACE:
                        ShowAllFlights();
                        break;

                    case var value when value == constantCollection.RESERVATION_INTERFACE:
                        ReservationSelected();
                        break;

                    case var value when value == constantCollection.CREATE_RESERVATION_INTERFACE:
                        CreateReservationSelected();
                        break;

                    case var value when value == constantCollection.DISPLAY_ALL_RESERVATION_INTERFACE:
                        DisplayAllReservationsSelected();
                        break;

                    case var value when value == constantCollection.SEARCH_RESERVATION_BY_PNR_NUMBER:
                        SearchReservationByPNR();
                        break;

                    default:
                        flag = false;
                        break;
                }
            }
        }

        public void MainScreen()
        {
            bool isValid;
            int chooseItem;

            Console.WriteLine("`````````````````````````````````````````");
            Console.WriteLine("\n\n\t 1 - Flight Maintenance");
            Console.WriteLine("\t 2 - Reservations");
            Console.WriteLine("`````````````````````````````````````````");
            Console.WriteLine(" Choose 1 or 2: ");

            isValid = int.TryParse(Console.ReadLine(), out chooseItem);

            if (isValid && chooseItem == 1)
            {
                chooseWhatToDo = constantCollection.FLIGHT_MAINTENANCE_INTERFACE;
            }
            else if (isValid && chooseItem == 2)
            {
                chooseWhatToDo = constantCollection.RESERVATION_INTERFACE;
            }
            else
            {
                InvalidInput(" Invalid Input!");
            }
        }

        private void FlightMaintenanceSelected()
        {
            bool isValid;
            int chooseItem;

            Console.WriteLine("`````````````````````````````````````````");
            Console.WriteLine("\t 1 - Add Flight");
            Console.WriteLine("\t 2 - Search Flight");
            Console.WriteLine("`````````````````````````````````````````");

            isValid = int.TryParse(Console.ReadLine(), out chooseItem);

            if (isValid && chooseItem == 1)
            {
                chooseWhatToDo = constantCollection.ADD_FLIGHT_INTERFACE;
            }
            else if (isValid && chooseItem == 2)
            {
                chooseWhatToDo = constantCollection.SEARCH_FLIGHT_INTERFACE;
            }
            else
            {
                InvalidInput(" Invalid Input!");
            }
        }

        private void AddFlightSelected()
        {
            var flightMaintenance = new FlightMaintenance();
            flightMaintenance.AddFlight();
            chooseWhatToDo = constantCollection.MAIN_INTERFACE;
        }

        private void SearchFlightSelected()
        {
            bool isValid;
            int chooseItem;

            Console.WriteLine("`````````````````````````````````````````");
            Console.WriteLine("\t 1 - Search by Airline Code");
            Console.WriteLine("\t 2 - Search by Flight Number");
            Console.WriteLine("\t 3 - Search by Origin and Destination");
            Console.WriteLine("\t 4 - Show all flights");
            Console.WriteLine("`````````````````````````````````````````");

            isValid = int.TryParse(Console.ReadLine(), out chooseItem);

            if (isValid && chooseItem == 1)
            {
                chooseWhatToDo = constantCollection.SEARCH_FLIGHT_BY_AIRLINE_CODE;
            }
            else if (isValid && chooseItem == 2)
            {
                chooseWhatToDo = constantCollection.SEARCH_FLIGHT_BY_FLIGHT_NUMBER;
            }
            else if (isValid && chooseItem == 3)
            {
                chooseWhatToDo = constantCollection.SEARCH_FLIGHT_BY_STATION;
            }
            else if (isValid && chooseItem == 4)
            {
                chooseWhatToDo = constantCollection.DISPLAY_ALL_FLIGHTS_INTERFACE;
            }
            else
            {
                InvalidInput(" Invalid Input!");
            }
        }

        private void SearchFlightByAirlineCodeSelected()
        {
            var flightMaintenance = new FlightMaintenance();
            flightMaintenance.SearchFlight(constantCollection.SEARCH_FLIGHT_BY_AIRLINE_CODE);
            chooseWhatToDo = constantCollection.MAIN_INTERFACE;
        }

        private void SearchFlightByFlightNumberSelected()
        {
            var flightMaintenance = new FlightMaintenance();
            flightMaintenance.SearchFlight(constantCollection.SEARCH_FLIGHT_BY_FLIGHT_NUMBER);
            chooseWhatToDo = constantCollection.MAIN_INTERFACE;
        }

        private void SearchFlightByStationSelected()
        {
            var flightMaintenance = new FlightMaintenance();
            flightMaintenance.SearchFlight(constantCollection.SEARCH_FLIGHT_BY_STATION);
            chooseWhatToDo = constantCollection.MAIN_INTERFACE;
        }

        private void ShowAllFlights()
        {
            var flightMaintenance = new FlightMaintenance();
            flightMaintenance.DisplayAllFlights();
            chooseWhatToDo = constantCollection.MAIN_INTERFACE;
        }

        private void ReservationSelected()
        {
            bool isValid;
            int chooseItem;

            Console.WriteLine("`````````````````````````````````````````");
            Console.WriteLine("\t 1 - Create Reservation");
            Console.WriteLine("\t 2 - Show All Reservations");
            Console.WriteLine("\t 3 - Search by PNR Number");
            Console.WriteLine("`````````````````````````````````````````");

            isValid = int.TryParse(Console.ReadLine(), out chooseItem);

            if (isValid && chooseItem == 1)
            {
                chooseWhatToDo = constantCollection.CREATE_RESERVATION_INTERFACE;
            }
            else if (isValid && chooseItem == 2)
            {
                chooseWhatToDo = constantCollection.DISPLAY_ALL_RESERVATION_INTERFACE;
            }
            else if (isValid && chooseItem == 3)
            {
                chooseWhatToDo = constantCollection.SEARCH_RESERVATION_BY_PNR_NUMBER;
            }
            else
            {
                InvalidInput(" Invalid Input!");
            }
        }

        private void CreateReservationSelected()
        {
            var reservation = new Reservations();
            reservation.CreateReservation();
            Console.WriteLine("Reservation Successfully Added!");
            chooseWhatToDo = constantCollection.MAIN_INTERFACE;
        }

        private void DisplayAllReservationsSelected()
        {
            var reservation = new Reservations();
            reservation.DisplayAllReservations();
            chooseWhatToDo = constantCollection.MAIN_INTERFACE;
        }

        private void SearchReservationByPNR()
        {
            var reservation = new Reservations();
            reservation.SearchReservation();
            chooseWhatToDo = constantCollection.MAIN_INTERFACE;
        }

        private void InvalidInput(string message)
        {
            Console.WriteLine($" Error: ");
            Console.WriteLine(" Press any key to continue.");
            Console.ReadLine();
            Console.Clear();
            chooseWhatToDo = constantCollection.MAIN_INTERFACE;
        }
    }
}
