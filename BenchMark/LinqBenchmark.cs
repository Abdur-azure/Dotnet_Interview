using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet_Interview.Interview
{
    public class LinqBenchmark
    {
        [Params(1, 10, 100)]
        public int N;

        [Benchmark]
        public void TraditionalLooping()
        {
            List<string> filteredList = new List<string>();
            for (int i = 0; i < N; i++)
            {
                string current = i.ToString();
                if (current.Length % 2 == 0)
                {
                    filteredList.Add(current);
                }
            }
        }

        [Benchmark]
        public void LinqLooping()
        {
            List<string> filteredList = Enumerable.Range(0, N)
                .Select(i => i.ToString())
                .Where(current => current.Length % 2 == 0)
                .ToList();
        }
    }
}
