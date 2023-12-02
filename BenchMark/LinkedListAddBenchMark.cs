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
    public class LinkedListAddBenchMark
    {
        [Params(1, 10, 100)]
        public int N;

        [Benchmark]
        public void ArrayMethod()
        {
            string[] myArray = new string[N];
            for (int i = 0; i < N; i++)
            {
                myArray[i] = $"{i}";
            }
        }

        [Benchmark]
        public void LinkedListMethod()
        {
            LinkedList<string> myLinkedList = new LinkedList<string>();
            for (int i = 0; i < N; i++)
            {
                myLinkedList.AddLast($"{i}");
            }
        }
    }
}
