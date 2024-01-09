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

    public class FreightFlightInfo : FreightFlightInfoBase
    {
        public string CharterCompany { get; set; }
        public string Cargo { get; set; }

        public string BuildFlightIdentifier() =>
          $"{Id} {DepartureLocation.Code}-" +
          $"{ArrivalLocation.Code} carrying " +
          $"{Cargo} for {CharterCompany}";

        public override string ToString() => BuildFlightIdentifier();
    }

}