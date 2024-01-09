namespace Dotnet_Interview.Refactoring
{
    public class FreightFlightInfoBase
    {
        public Airport ArrivalLocation { get; set; }
        public DateTime ArrivalTime { get; set; }
        public Airport DepartureLocation { get; set; }
        public DateTime DepartureTime { get; set; }
        public TimeSpan Duration => DepartureTime - ArrivalTime;
        public string Id { get; set; }
    }
}