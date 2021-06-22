using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_JLG
{
    public class RepositoryCollection
    {
        public RepositoryCollection()
        {

        }

        // Collection of all Available Flights
        private static List<IFlightInformation> AvailableFlightsList = new List<IFlightInformation>();
        // Collection of all Reserved Flights
        private static Dictionary<string, Reservation> ReservationCollection = new Dictionary<string, Reservation>();
        // Last PNR Generated
        private static char[] PassengerNameRecord { get; set; }

        /// <summary>
        /// Add a flight in the collection
        /// </summary>
        /// <param name="flight"></param>
        public void AddRecord(IFlightInformation flight)
        {
            AvailableFlightsList.Add(flight);
        }

        /// <summary>
        /// Add reservation in the collection
        /// </summary>
        /// <param name="passengerNameRecord"></param>
        /// <param name="reservation"></param>
        public void AddRecord(string passengerNameRecord, Reservation reservation)
        {
            ReservationCollection.Add(passengerNameRecord, reservation);
        }

        /// <summary>
        /// Get all available flights
        /// </summary>
        /// <returns>List of available flights</returns>
        public List<IFlightInformation> GetAllFlights()
        {
            return AvailableFlightsList;
        }

        /// <summary>
        /// Get all reservations
        /// </summary>
        /// <returns> Dictionary of reservations </returns>
        public Dictionary<string, Reservation> GetAllReservations()
        {
            return ReservationCollection;
        }

        /// <summary>
        /// Generate new PNR
        /// </summary>
        /// <returns> New Generated PNR </returns>
        public string GeneratePNR()
        {
            var hasIncremented = false;
            // Check if there is already a generated PNR
            var currentPNR = PassengerNameRecord ?? new char[] { 'Z', '9', '9', '9', '9', '9' };

            // Check 2nd to last character on which to increment
            for (int i = currentPNR.Length - 1; i > 0; i--)
            {
                // If character is number 9, it should check the next character
                if (currentPNR[i] != '9')
                {
                    // If character is letter Z, next incrementation is a number
                    if ((int)currentPNR[i] != 'Z')
                    {
                        currentPNR[i]++;
                        hasIncremented = true;
                        break;
                    }
                    else
                    {
                        currentPNR[i] = '0';
                        hasIncremented = true;
                        break;
                    }
                }
            }

            // If 2nd to last character is 9, 1st character will increment
            if (!hasIncremented && currentPNR[0] != 'Z')
            {
                currentPNR[0]++;
                hasIncremented = true;
            }
            // If all possible combinations is used, reset to start
            if (!hasIncremented) currentPNR = new char[] { 'A', 'A', 'A', 'A', 'A', 'A' };
            // Save the last generated PNR into the collections
            PassengerNameRecord = currentPNR;
            return new string(currentPNR);
        }
    }
}
