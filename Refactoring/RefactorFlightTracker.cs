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

        public void DisplayFlights()
        {
            foreach (RefactorFlight f in _flights)
            {
                Console.WriteLine($"{f.Id,-9} {f.Destination,-5} {Format(f.DepartureTime),-21} {f.Gate,-5} {f.Status}");
            }
        }

        public RefactorFlight? DelayFlight(string fId, DateTime newDepartureTime)
        {
                RefactorFlight? flight = FindFlightById(fId);

            if (flight != null)
            {
                flight.DepartureTime = newDepartureTime;
                flight.Status = FlightStatus.Delayed;
                Console.WriteLine($"{fId} delayed until {Format(newDepartureTime)}");
            }
            else
            {
                Console.WriteLine($"{fId} could not be found");
            }
            return flight;
        }

        public RefactorFlight? MarkFlightArrived(string id,
            DateTime arrivalTime, string gate = "TBD")
        {
            RefactorFlight? flight = FindFlightById(id);
            if (flight != null)
            {
                flight.ArrivalTime = arrivalTime;
                flight.Status = FlightStatus.OnTime;
                flight.Gate = gate;
                Console.WriteLine($"{id} arrived at {Format(arrivalTime)}.");
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
                Console.WriteLine($"{id} departed at {Format(departureTime)}.");
            }
            else
            {
                Console.WriteLine($"{id} could not be found");
            }
            return flight;
        }

        private RefactorFlight? FindFlightById(string id)
        {
            return _flights.FirstOrDefault(f => f.Id == id);
        }

        public string Format(DateTime time)
        {
            return time.ToString("ddd MMM dd HH:mm tt");
        }
    }
}