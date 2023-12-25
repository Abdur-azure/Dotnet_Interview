using BenchmarkDotNet.Running;
//using Dotnet_Interview.BenchMark;
//using Dotnet_Interview.Interview;
using Dotnet_Interview.Refactoring;

namespace Dotnet_Interview;

class Program
{
    static void Main(string[] args)
    {
        //BenchmarkRunner.Run<StringAppendBenchmark>();
        //BenchmarkRunner.Run<LinkedListAddBenchMark>();
        //BenchmarkRunner.Run<EncryptionBenchMark>();
        //BenchmarkRunner.Run<LinqBenchmark>();
        //BenchmarkRunner.Run<StringBuilderBenchMark>();

        //Refactor

        //BaggageCalculator
        //int numChecked = 2;
        //int numCarryOn = 1;
        //int numPassengers = 2;

        //RefactorBaggageCalculator baggageCalculator
        //     = new();
        //DateTime travelTime = DateTime.Now;
        //decimal price = baggageCalculator.CalculatePrice(numChecked, numCarryOn, numPassengers, travelTime.Month >= 11 || travelTime.Month <= 2);

        //Console.WriteLine($"{numChecked} checked and {numCarryOn} carry-on bags for {numPassengers} passengers is {price:C}");

        //Boarding Processor
        //PassengerGenerator generator = new();
        //IEnumerable<Passenger> passengers = generator.GeneratePassengers(18).OrderBy(p => p.BoardingGroup);

        //BoardingProcessor boardingProcessor = new();
        //boardingProcessor.CurrentBoardingGroup = 4;
        //boardingProcessor.Status = BoardingStatus.Boarding;

        //Random random = new();

        //foreach (var passenger in passengers.Where(p => boardingProcessor.CanPassengerBoard(p).StartsWith("Board")))
        //{
        //    passenger.HasBoarded = random.NextDouble() < 0.65;
        //}

        //boardingProcessor.DisplayBoardingStatus(passengers.ToList());

        //Flight Tracker
        RefactorFlightTracker refactorFlightTracker = new();

            Random rand = new();
            string[] destinations = { "CMH", "ATL", "MCI", "CLT", "SAN", "ORD", "CHS", "PNS" };
            string[] gates = { "A01", "A02", "A03", "A04", "C01", "C02", "C03", "C04" };
            int nextId = 2024;

            DateTime nextFlightTime = DateTime.Now;
            for (int i = 0; i < 15; i++)
            {
                nextFlightTime = nextFlightTime.AddMinutes(rand.Next(1, 25));

                AddRandomFlight(refactorFlightTracker, rand, destinations, gates, nextId, nextFlightTime);

                nextId += rand.Next(1, 7);
            }

            Console.WriteLine();
            Console.WriteLine("FLIGHT    DEST  DEPARTURE             GATE  STATUS");
            Console.WriteLine();
            refactorFlightTracker.DisplayFlights();
        }

        private static void AddRandomFlight(RefactorFlightTracker refactorFlightTracker, Random rand, string[] destinations, string[] gates, int nextId, DateTime nextFlightTime)
        {
            string dest = destinations[rand.Next(destinations.Length)];
            string gate = gates[rand.Next(gates.Length)];
            Flight flight = refactorFlightTracker.ScheduleNewFlight($"CSA{nextId}", dest, nextFlightTime);

            _ = rand.Next(8) switch
            {
                0 => flight.Status = FlightStatus.Inbound,
                1 => flight.Status = FlightStatus.Delayed,
                2 => flight.Status = FlightStatus.Cancelled,
                _ => flight.Status = FlightStatus.OnTime
        };
    }
}
