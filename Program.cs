using BenchmarkDotNet.Running;
using Dotnet_Interview.Interview;

namespace Dotnet_Interview;

class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<StringAppendBenchmark>();
    }
}
