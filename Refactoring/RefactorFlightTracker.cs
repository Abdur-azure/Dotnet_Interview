using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet_Interview.Refactoring
{
    public class RefactorFlightTracker
    {
        private readonly List<RefactorFlight> _flights = new();

        public RefactorFlight ScheduleNewFlight(string id, string dest, DateTime depart)
        {
            RefactorFlight refactorFlight = new(id,dest, depart)
            {
                Status = FlightStatus.Inbound
            };
            return ScheduleNewFlight(refactorFlight);
        }

        public RefactorFlight ScheduleNewFlight(RefactorFlight flight)
        {
            _flights.Add(flight);
            return flight;
        }

        public void DisplayMatchingFlights(List<RefactorFlight> flights, Func<Flight, bool> shouldDisplay)
        {
            foreach (RefactorFlight flight in flights)
            {
                Console.WriteLine(flight);
            }
        }

        public RefactorFlight? MarkFlightDelayed(string fId, DateTime newDepartureTime)
        {
            Action<RefactorFlight> updateAction = (flight) =>
            {
                flight.DepartureTime = newDepartureTime;
                flight.Status = FlightStatus.Inbound;
                Console.WriteLine($"{fId} delayed to {DateHelpers.Format(newDepartureTime)}");
            };

            return UpdateFlight(fId, updateAction);
        }

        public RefactorFlight? MarkFlightArrived(string id,
            DateTime arrivalTime, string gate = "TBD")
        {
            RefactorFlight? flight = FindFlightById(id);
            if (flight != null)
            {
                flight.ArrivalTime = arrivalTime;
                flight.Gate = gate;
                flight.Status = FlightStatus.OnTime;
                Console.WriteLine($"{id} arrived at {DateHelpers.Format(arrivalTime)}.");
            }
            else
            {
                Console.WriteLine($"{id} could not be found");
            }
            return flight;
        }

        public RefactorFlight? MarkFlightDeparted(string id, DateTime departureTime)
        {
            RefactorFlight? flight = FindFlightById(id);
            if (flight != null)
            {
                flight.DepartureTime = departureTime;
                flight.Status = FlightStatus.Departed;
                Console.WriteLine($"{id} departed at {DateHelpers.Format(departureTime)}.");
            }
            else
            {
                Console.WriteLine($"{id} could not be found");
            }
            return flight;
        }

        private RefactorFlight? FindFlightById(string id) => 
            _flights.FirstOrDefault(f => f.Id == id);

        private RefactorFlight? UpdateFlight(string id, Action<RefactorFlight> updateAction) 
        {
            RefactorFlight? flight = FindFlightById(id);
            if (flight != null)
            {
                updateAction(flight);
            }
            else 
            {
                Console.WriteLine($"{id} could not be found");
            }
            return flight;
        }
    }
}