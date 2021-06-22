using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ARS_JLG
{
    public class GetUserInput
    {
        public GetUserInput()
        {

        }

        private delegate int AskNumberCompleted(string message);
        private delegate DateTime AskDateCompleted(string message);
        private delegate DateTime AskTimeCompleted(string message);

        public string AskStringToUpper(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine().ToUpper().Trim();
        }

        public string AskStringValue(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine().Trim();
        }

        public int AskNumber(string message)
        {
            Console.WriteLine(message);
            var consoleInput = Console.ReadLine().Trim();
            var isValid = ValidateInputIfNumber(consoleInput);
            int? inputNumber = null;

            if (!isValid)
            {
                Console.WriteLine(" Error: Input must be a number");
                inputNumber = AskNumber(message, AskNumber);
            }

            if (inputNumber == null) inputNumber = int.Parse(consoleInput);

            return inputNumber ?? default;
        }

        private int AskNumber(string message, AskNumberCompleted askNumber)
        {
            return askNumber(message);
        }

        private bool ValidateInputIfNumber(string consoleInput)
        {
            return Regex.IsMatch(consoleInput, @"^-?[0-9]+$");
        }

        public DateTime AskDate(string message)
        {
            Console.WriteLine(message);
            var consoleInput = Console.ReadLine().Trim();
            var isValid = ValidateFlightDateFormat(consoleInput);
            DateTime? inputDate = null;

            if (!isValid)
            {
                Console.WriteLine(" Error: Input must be a date format (mm/dd/yyyy)");
                Console.WriteLine(" Re-enter Input: ");
                inputDate = AskDate(message, AskDate);
            }

            if (inputDate == null) inputDate = DateTime.Parse(consoleInput);

            return inputDate ?? default;
        }
        
        private DateTime AskDate(string message, AskDateCompleted askDate)
        {
            return AskDate(message);
        }

        private bool ValidateFlightDateFormat(string consoleInput)
        {
            DateTime reservationDate;
            var validDateFormats = new string[] { "M/d/yyyy", "M/dd/yyyy", "MM/d/yyyy", "MM/dd/yyyy" };
            var isValid = false;

            isValid = DateTime.TryParseExact(consoleInput, validDateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out reservationDate);

            return isValid;
        }

        public DateTime AskTime(string message)
        {
            Console.WriteLine(message);
            var consoleInput = Console.ReadLine().Trim();
            var isValid = ValidateTimeFormat(consoleInput);
            DateTime? inputTime = null;

            if (!isValid)
            {
                Console.WriteLine(" Error: Input must be a 24-hour time format (hh:mm)");
                Console.WriteLine(" Re-enter Input: ");
                inputTime = AskTime(message, AskTime);
            }

            if (inputTime == null) inputTime = DateTime.Parse(consoleInput);

            return inputTime ?? default;
        }

        private DateTime AskTime(string message, AskTimeCompleted askTime)
        {
            return askTime(message);
        }

        private bool ValidateTimeFormat(string consoleInput)
        {
            DateTime dateTime;
            var validTimeFormats = new string[] { "H:mm", "HH:mm" };
            bool isValid;

            isValid = DateTime.TryParseExact(consoleInput, validTimeFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);

            return isValid;
        }
    }
}
