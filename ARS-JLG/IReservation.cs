using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_JLG
{
    public interface IReservation : IFlights
    {
        public int NumberOfPassengers { get; set; }
        public DateTime FlightDate { get; set; }
        public List<Passenger> PassengerList { get; set; }
    }
}
