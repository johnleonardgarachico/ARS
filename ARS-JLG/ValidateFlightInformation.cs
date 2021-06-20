using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ARS_JLG
{
    public class ValidateFlightInformation
    {
        public ValidateFlightInformation()
        {

        }

        private delegate string GetAirlineCodeCompleted();
        private delegate int GetFlightNumberCompleted();
        private delegate string GetStationCompleted(string stationToCheck);
        private delegate DateTime GetTimeScheduleCompleted(string inputTime);

        /// <summary>
        /// Check if entered airline code is valid
        /// </summary>
        /// <param name="flight"></param>
        public string GetAirlineCode()
        {
            var isValid = false;
            string airlineCode;

            Console.WriteLine(" Enter Airline Code: ");
            airlineCode = Console.ReadLine().ToUpper();
            isValid = ValidateAirlineCode(airlineCode);

            if (!isValid)
            {
                Console.WriteLine(" Error: Invalid Airline Code");
                airlineCode = GetAirlineCode(GetAirlineCode);
            }

            return airlineCode;
        }

        /// <summary>
        /// Callback until the entered airline code is valid
        /// </summary>
        /// <param name="flight"></param>
        /// <param name="validateInput"></param>
        private string GetAirlineCode(GetAirlineCodeCompleted validateInput)
        {
            return validateInput();
        }

        /// <summary>
        /// Check Airline Code Requirements
        /// </summary>
        /// <param name="airlineCode"></param>
        /// <returns> Status if the entered value is valid </returns>
        private bool ValidateAirlineCode(string airlineCode)
        {
            var isValid = false;
            var regexRestriction = new Regex("^[A-Z][A-Z0-9]*$");

            //Airline Code should have 2 characters
            if (airlineCode.Length == 2)
            {
                isValid = regexRestriction.IsMatch(airlineCode);
            }

            return isValid;
        }

        /// <summary>
        /// Check if the entered character is a number
        /// </summary>
        /// <param name="consoleInput"></param>
        public int GetFlightNumber()
        {
            var isValid = false;
            int inputNumber;
            string consoleInput;

            Console.WriteLine(" Enter Flight Number: ");
            consoleInput = Console.ReadLine();
            isValid = int.TryParse(consoleInput, out inputNumber);

            if (!isValid)
            {
                Console.WriteLine(" Error: Input should be a number");
                GetFlightNumber(GetFlightNumber);
            }

            isValid = ValidateFlightNumber(inputNumber);

            if (!isValid)
            {
                Console.WriteLine(" Error: Input number should be (1 ~ 9999)");
                inputNumber = GetFlightNumber(GetFlightNumber);
            }

            return inputNumber;
        }

        /// <summary>
        /// Callback for re-entering invalid character input
        /// </summary>
        /// <param name="consoleInput"></param>
        /// <param name="validateInput"></param>
        private int GetFlightNumber(GetFlightNumberCompleted validateInput)
        {
            return validateInput();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flightNumber"></param>
        /// <returns></returns>
        private bool ValidateFlightNumber(int flightNumber)
        {
            var isValid = false;

            if (flightNumber >= 1 && flightNumber <= 9999) isValid = true;

            return isValid;
        }

        /// <summary>
        /// Check entered character if a valid station
        /// </summary>
        /// <param name="station"></param>
        public string GetStation(string stationToCheck)
        {
            var isValid = false;
            string consoleInput;

            Console.WriteLine($" Enter {stationToCheck}: ");
            consoleInput = Console.ReadLine().ToUpper();

            isValid = ValidateStation(consoleInput);

            if (!isValid)
            {
                Console.WriteLine(" Error: Invalid Station");
                consoleInput = GetStation(stationToCheck, GetStation);
            }

            return consoleInput;
        }

        /// <summary>
        /// Callback for re-entering invalid station.
        /// </summary>
        /// <param name="station"></param>
        /// <param name="validateInput"></param>
        private string GetStation(string stationToCheck, GetStationCompleted validateInput)
        {
            return validateInput(stationToCheck);
        }

        /// <summary>
        /// Check Station Requirements
        /// </summary>
        /// <param name="station"></param>
        /// <returns></returns>
        private bool ValidateStation(string station)
        {
            var isValid = false;
            var regexRestriction = new Regex("^[A-Z][A-Z0-9]*$");

            //Check if station consists of 3 characters
            if (station.Length == 3)
            {
                isValid = regexRestriction.IsMatch(station);
            }

            return isValid;
        }

        /// <summary>
        /// Check if entered character is a valid time
        /// </summary>
        /// <param name="inputTime"></param>
        /// <returns> Entered time in TimeSpan Type </returns>
        public DateTime GetTimeSchedule(string timeToCheck)
        {
            var isValid = false;
            DateTime dateTime;
            var validTimeFormats = new string[] { "H:mm", "HH:mm" };
            string consoleInput;

            Console.WriteLine($"Enter {timeToCheck} [HH:mm] :");
            consoleInput = Console.ReadLine();

            isValid = DateTime.TryParseExact(consoleInput, validTimeFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);

            if (!isValid)
            {
                Console.WriteLine("Invalid Time!");
                dateTime = GetTimeSchedule(timeToCheck, GetTimeSchedule);
            }
            return dateTime;
        }

        /// <summary>
        /// Callback if Entered time is invalid
        /// </summary>
        /// <param name="inputTime"></param>
        /// <param name="validateInput"></param>
        /// <returns></returns>
        private DateTime GetTimeSchedule(string timeToCheck, GetTimeScheduleCompleted validateInput)
        {
            return validateInput(timeToCheck);
        }
    }
}
