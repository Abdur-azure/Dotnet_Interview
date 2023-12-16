using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet_Interview.Refactoring
{
    public class Flight
    {
        public string Id { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string Gate { get; set; }
        public FlightStatus Status { get; set; }

        public override string ToString()
        {
            return $"{Id} to {Destination} at {DepartureTime}";
        }
    }
}
