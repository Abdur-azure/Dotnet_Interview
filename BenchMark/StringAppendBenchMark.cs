using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet_Interview.Interview
{
    /*[SimpleJob(RuntimeMoniker.Net481)]
    [SimpleJob(RuntimeMoniker.Net50)]
    [SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net70)]
    [SimpleJob(RuntimeMoniker.NativeAot70)]
    [SimpleJob(RuntimeMoniker.Mono)]*/
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
