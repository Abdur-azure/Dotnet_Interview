using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet_Interview.Interview
{
    public class StringAppendBenchmark
    {
        [Params(1, 10, 100)]
        public int N;

        [Benchmark]
        public void Concatenate()
        {
            string aString = "";
            for (int i = 0; i < N; i++)
            {
                aString += i;
            }
        }

        [Benchmark]
        public void StringBuilder()
        {
            StringBuilder aString = new("");
            for (int i = 0;i < N; i++)
            {
                aString.Append(i);
            }
        }
    }
}
