using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_JLG
{
    public class FlightMaintenance
    {
        public FlightMaintenance()
        {

        }

        public void AddFlight()
        {
            var CreateFlight = new CreationFlight();
            bool isFlightExists;
            bool isValid;

            isFlightExists = CreateFlight.GetInitialInformation();

            if (!isFlightExists)
            {
                CreateFlight.GetFinalInformation();
                isValid = CreateFlight.CreateFlight();

                if (isValid)
                {
                    Console.WriteLine("Flight Successfully Added!");
                }
                else
                {
                    Console.WriteLine("Invalid Flight Information!");
                }
            }
            else
            {
                Console.WriteLine("Flight is Already Existing!");
            }
        }

        public void SearchFlight(int searchMethod)
        {
            var constantCollection = new Constants();
            var constMessage = new ConstantMessage();
            var getInput = new GetUserInput();
            var searchFlight = new SearchFlight();
            var displayInterface = new GetUserOutput();
            var listOfFlights = new List<IFlightInformation>();
            var hasFlight = false;

            if (searchMethod == constantCollection.SEARCH_FLIGHT_BY_AIRLINE_CODE)
            {
                hasFlight = searchFlight.TrySearchForFlight(getInput.AskStringToUpper(constMessage.ASK_AIRLINE_CODE), out listOfFlights);
            }
            else if (searchMethod == constantCollection.SEARCH_FLIGHT_BY_FLIGHT_NUMBER)
            {
                hasFlight = searchFlight.TrySearchForFlight(getInput.AskNumber(constMessage.ASK_FLIGHT_NUMBER), out listOfFlights);
            }
            else if (searchMethod == constantCollection.SEARCH_FLIGHT_BY_STATION)
            {
                hasFlight = searchFlight.TrySearchForFlight(getInput.AskStringToUpper(constMessage.ASK_ARRIVAL_STATION), 
                    getInput.AskStringToUpper(constMessage.ASK_DEPARTURE_STATION), out listOfFlights);
            }
            else
            {
                Console.WriteLine("Invalid Search Method!");
            }

            if (hasFlight)
            {
                displayInterface.DisplayFlights(listOfFlights);
            }
            else
            {
                Console.WriteLine("No flight existing with the given information!");
            }
        }

        public void DisplayAllFlights()
        {
            var flightCollection = new RepositoryCollection();
            var displayInterface = new GetUserOutput();

            var flightList = flightCollection.GetAllFlights();

            if (flightList.Count != 0)
            {
                displayInterface.DisplayFlights(flightCollection.GetAllFlights());
            }
            else
            {
                Console.WriteLine("No flight is existing in the record!");
            }
        }
    }
}
