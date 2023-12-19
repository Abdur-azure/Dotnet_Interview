﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet_Interview.Refactoring
{
    public class RefactorFlightTracker
    {
        private readonly List<Flight> _flights = new();

        public Flight ScheduleNewFlight(string id, string dest, DateTime depart, string gate)
        {
            Flight flight = new()
            {
                Id = id,
                Destination = dest,
                DepartureTime = depart,
                Gate = gate,
                Status = FlightStatus.Inbound
            };
            return ScheduleNewFlight(flight);
        }

        public Flight ScheduleNewFlight(Flight flight)
        {
            _flights.Add(flight);
            return flight;
        }

        public void DisplayFlights()
        {
            foreach (Flight f in _flights)
            {
                Console.WriteLine($"{f.Id,-9} {f.Destination,-5} {Format(f.DepartureTime),-21} {f.Gate,-5} {f.Status}");
            }
        }

        public Flight? DelayFlight(string fId, DateTime newDepartureTime)
        {
            Flight? flight = FindFlightById(fId);

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

        public Flight? MarkFlightArrived(DateTime arrivalTime, string id)
        {
            Flight? flight = FindFlightById(id);
            if (flight != null)
            {
                flight.ArrivalTime = arrivalTime;
                flight.Status = FlightStatus.OnTime;
                Console.WriteLine($"{id} arrived at {Format(arrivalTime)}.");
            }
            else
            {
                Console.WriteLine($"{id} could not be found");
            }
            return flight;
        }

        public Flight? MarkFlightDeparted(string id, DateTime departureTime)
        {
            Flight? flight = FindFlightById(id);
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

        private Flight? FindFlightById(string id)
        {
            return _flights.FirstOrDefault(f => f.Id == id);
        }

        public string Format(DateTime time)
        {
            return time.ToString("ddd MMM dd HH:mm tt");
        }
    }
}