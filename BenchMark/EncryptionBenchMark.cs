﻿using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using System.Security.Cryptography;

namespace Dotnet_Interview.Interview
{
    //[SimpleJob(RuntimeMoniker.Net70, baseline: true)]
    //[SimpleJob(RuntimeMoniker.Net80)]
    //[RPlotExporter]
    public class EncryptionBenchMark
    {
        private SHA256 sha256 = SHA256.Create();
        private MD5 md5 = MD5.Create();
        private byte[] data;

        [Params(1000, 10000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            data = new byte[N];
            new Random(42).NextBytes(data);
        }

        [Benchmark]
        public byte[] Sha256() => sha256.ComputeHash(data);

        [Benchmark]
        public byte[] Md5() => md5.ComputeHash(data);
    }

}