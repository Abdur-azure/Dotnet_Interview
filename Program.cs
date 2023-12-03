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

        //Refactor

        //BaggageCalculator
        int numChecked = 2;
        int numCarryOn = 1;
        int numPassengers = 2;

        BaggageCalculator baggageCalculator
             = new();
        DateTime travelTime = DateTime.Now;
        decimal price = baggageCalculator.CalculatePrice(numChecked, numCarryOn, numPassengers, numPassengers, travelTime);

        Console.WriteLine($"{numChecked} checked and {numCarryOn} carry-on bags for {numPassengers} passengers is {price:C}");
    }
}
