using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using MyLibrary;

namespace BenchmarkConsole
{
    [MemoryDiagnoser]
    [HtmlExporter]
    [RankColumn()]
    public class DemoBenchmark
    {
        private readonly string isoDate = "2021-03-12";
        private static DemoClass demoClass = new DemoClass();
        private List<int> listOfInts;
        private int value = 50;

        [GlobalSetup]
        public void Setup()
        {
            var rnd = new Random(123);
            listOfInts = new List<int>();
            for (int i = 0; i < 1000; i++)
            {
                listOfInts.Add(rnd.Next(100));
            }
        }
        [Benchmark(Baseline = true)]
        public int GetYearByDateConvert() => demoClass.GetYearByDateConvert(isoDate);

        [Benchmark]
        public int GetYearByParseDate() => demoClass.GetYearByParseDate(isoDate);
        [Benchmark]
        public int GetYearBySplit() => demoClass.GetYearBySplit(isoDate);
        [Benchmark]
        public int GetYearBySubstring() => demoClass.GetYearBySubstring(isoDate);
        [Benchmark]
        public int GetYear_SuperFast() => demoClass.GetYear_SuperFast(isoDate);


        //[Benchmark]
        public bool ContainsElementsWhere() => demoClass.ContainsElementsWhere(listOfInts, value);
        //[Benchmark]
        public bool ContainsElementsCount() => demoClass.ContainsElementsCount(listOfInts, value);
        //[Benchmark]
        public bool ContainsElementsAny() => demoClass.ContainsElementsAny(listOfInts, value);
    }
}
