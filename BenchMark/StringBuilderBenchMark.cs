using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet_Interview.BenchMark
{
    [MemoryDiagnoser]
    public class StringBuilderBenchMark
    {
        [Params(1, 10, 100)]
        public int N;

        [Benchmark]
        public string StringJoin()
        {
          return string.Join(", ", Enumerable.Range(0, N).Select(i => i.ToString()));
        }

        [Benchmark]
        public string StringBuilder()
        {
          var sb = new StringBuilder();
          for (int i = 0; i < N; i++)
          {
              sb.Append(i);
              sb.Append(", ");
          }

          return sb.ToString();
        }
    }
}
