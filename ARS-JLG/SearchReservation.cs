using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_JLG
{
    public class SearchReservation
    {
        public SearchReservation()
        {

        }

        /// <summary>
        /// Search reservation by PNR
        /// </summary>
        /// <param name="PNR"></param>
        /// <param name="foundReservation"></param>
        /// <returns> Status if reservation exists</returns>
        public bool SearchForReservation(string PNR, out Reservation foundReservation)
        {
            var hasReservation = false;
            var repositoryCollection = new RepositoryCollection();

            hasReservation = repositoryCollection.GetAllReservations().TryGetValue(PNR, out foundReservation);

            return hasReservation;
        }
    }
}
