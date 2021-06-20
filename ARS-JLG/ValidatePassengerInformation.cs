using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ARS_JLG
{
    public class ValidatePassengerInformation
    {
        public ValidatePassengerInformation()
        {

        }

        private delegate string GetPassengerNameCompleted(string nameToGet);
        private delegate DateTime GetBirthDateCompleted(out int age);

        public string GetPassengerName(string nameToGet)
        {
            var isValid = false;
            var consoleInput = "";
            var regexRestriction = new Regex("^[a-zA-Z0-9 ]*$");
            
            // Check if the entered input only contains letter
            Console.WriteLine($" Enter {nameToGet}: ");
            consoleInput = Console.ReadLine();
            isValid = regexRestriction.IsMatch(consoleInput);
            // Re-enter first name if it contains other characters
            if (!isValid)
            {
                Console.WriteLine(" Error: Name must only contain letters");
                consoleInput = GetPassengerName(nameToGet,GetPassengerName);
            }
            // Check if entered name does not exceed 20 characters
            if (consoleInput.Length > 20)
            {
                Console.WriteLine(" Error: First Name can have up to 20 characters only");
                consoleInput = GetPassengerName(nameToGet,GetPassengerName);
            }

            return consoleInput;
        }

        private string GetPassengerName(string nameToGet, GetPassengerNameCompleted getPassengerName)
        {
            return getPassengerName(nameToGet);
        }

        public DateTime GetBirthDate(out int age)
        {
            var isValid = false;
            var consoleInput = "";
            DateTime birthDate;
            var validDateFormats = new string[] { "M/d/yyyy", "M/dd/yyyy", "MM/d/yyyy", "MM/dd/yyyy" };

            // Get input for birth date
            Console.WriteLine(" Enter Birth Date (mm/dd/yyyy): ");
            consoleInput = Console.ReadLine();
            // Check if the entered date is in a valid format
            isValid = DateTime.TryParseExact(consoleInput, validDateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate);
            // Re-enter date if it is invalid
            if (!isValid)
            {
                Console.WriteLine(" Error: Invalid Date Format! Please enter in this format (mm/dd/yyyy)");
                Console.WriteLine(" Enter Birth Date (mm/dd/yyyy): ");
                birthDate = GetBirthDate(out age,GetBirthDate);
            }
            // Check if birth date is a future date
            if (birthDate.Date > DateTime.Now.Date)
            {
                Console.WriteLine(" Error: Invalid Date! (Birth date cannot be future date)");
                Console.WriteLine(" Enter Birth Date (mm/dd/yyyy): ");
                birthDate = GetBirthDate(out age,GetBirthDate);
            }
            
            // Calculate Age 
            age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now.DayOfYear - birthDate.DayOfYear < 0) age--;

            return birthDate;
        }

        private DateTime GetBirthDate(out int age,GetBirthDateCompleted getBirthDate)
        {
            return getBirthDate(out age);
        }
    }
}
