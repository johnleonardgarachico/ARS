using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ARS_JLG
{
    public class Passenger
    {
        public Passenger()
        {
            FirstName = null;
            LastName = null;
            BirthDate = DateTime.MaxValue;
            Age = 0;
        }

        public Passenger(string firstName, string lastName, DateTime birthDate, out bool isInformationValid)
        {
            isInformationValid = ValidatePassengerInformation(firstName, lastName, birthDate);

            if(isInformationValid)
            {
                FirstName = firstName;
                LastName = lastName;
                BirthDate = birthDate;
                Age = CalculateAge(birthDate);
            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }

        public bool ValidatePassengerInformation(string firstName, string lastName, DateTime birthDate)
        {
            var errorMessage = new ConstantMessage();
            var isValid = true;

            if (!ValidatePassengerName(firstName)) errorMessage.DisplayErrorMessage(errorMessage.ERR_MSG_FIRST_NAME, out isValid);
            if (!ValidatePassengerName(lastName)) errorMessage.DisplayErrorMessage(errorMessage.ERR_MSG_LAST_NAME, out isValid);
            if (!ValidateBirthDate(birthDate)) errorMessage.DisplayErrorMessage(errorMessage.ERR_MSG_BIRTH_DATE, out isValid);

            return isValid;
        }

        private bool ValidatePassengerName(string name)
        {
            return Regex.IsMatch(name, @"^(?=.*\S)([A-Za-z ]{1,20})$");
        }

        private bool ValidateBirthDate(DateTime birthDate)
        {
            var isValid = true;

            if (birthDate.Date >= DateTime.Now.Date) isValid = false;

            return isValid;
        }

        private int CalculateAge(DateTime birthDate)
        {
            var age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now.DayOfYear - birthDate.DayOfYear < 0) age--;

            return age;
        }
    }
}
