using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet_Interview.Refactoring
{
    public interface IFlightInfo
    {
        string Id { get; }
        Airport DepartureLocation { get; }
        Airport ArrivalLocation { get; }
        DateTime DepartureTime { get; }
        DateTime ArrivalTime { get; }
        TimeSpan Duration { get; }
    }

    public class FreightFlightInfo : IFlightInfo
    {
        public string Id { get; set; }
        public Airport DepartureLocation { get; set; }
        public Airport ArrivalLocation { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public TimeSpan Duration => DepartureTime - ArrivalTime;
        public string CharterCompany { get; set; }
        public string Cargo { get; set; }

        public string BuildFlightIdentifier() =>
          $"{Id} {DepartureLocation.Code}-" +
          $"{ArrivalLocation.Code} carrying " +
          $"{Cargo} for {CharterCompany}";

        public override string ToString() => BuildFlightIdentifier();
    }

}