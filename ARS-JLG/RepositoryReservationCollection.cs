using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_JLG
{
    public class RepositoryReservationCollection
    {
        public RepositoryReservationCollection()
        {

        }

        public void AddReservation(string PNR, IReservation reservation)
        {
            DataBaseCollection.ReservationCollection.Add(PNR, reservation);
        }

        public Dictionary<string, IReservation> GetAllReservations()
        {
            return DataBaseCollection.ReservationCollection;
        }

        public bool SearchByPNR(string PNR, out IReservation foundReservation)
        {
            var hasReservation = false;

            hasReservation = DataBaseCollection.ReservationCollection.TryGetValue(PNR, out foundReservation);

            return hasReservation;
        }

        public string GeneratePNR()
        {
            var hasIncremented = false;
            // Check if there is already a generated PNR
            var currentPNR = DataBaseCollection.PassengerNameRecord ?? new char[] { 'Z','9','9','9','9','9'};

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
            DataBaseCollection.PassengerNameRecord = currentPNR;
            return new string(currentPNR);
        }   
    }
}
