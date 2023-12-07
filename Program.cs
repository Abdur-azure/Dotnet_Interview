using BenchmarkDotNet.Running;
using Dotnet_Interview.BenchMark;
using Dotnet_Interview.Interview;
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

        /*Refactor

        BaggageCalculator
        int numChecked = 2;
        int numCarryOn = 1;
        int numPassengers = 2;

        RefactorBaggageCalculator baggageCalculator
             = new();
        DateTime travelTime = DateTime.Now;
        decimal price = baggageCalculator.CalculatePrice(numChecked, numCarryOn, numPassengers, travelTime.Month >= 11 || travelTime.Month <= 2);

        Console.WriteLine($"{numChecked} checked and {numCarryOn} carry-on bags for {numPassengers} passengers is {price:C}");

        Boarding Processor*/
        PassengerGenerator generator = new();
        IEnumerable<Passenger> passengers = generator.GeneratePassengers(18).OrderBy(p => p.BoardingGroup);

        BoardingProcessor boardingProcessor = new();
        boardingProcessor.CurrentBoardingGroup = 4;
        boardingProcessor.Status = BoardingStatus.Boarding;

        Random random = new();

        foreach (var passenger in passengers.Where(p => boardingProcessor.CanPassengerBoard(p).StartsWith("Board")))
        {
            passenger.HasBoarded = random.NextDouble() < 0.65;
        }

        boardingProcessor.DisplayBoardingStatus(passengers.ToList());
    }
}
