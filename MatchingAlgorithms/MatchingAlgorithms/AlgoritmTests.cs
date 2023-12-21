using BenchmarkDotNet.Attributes;

namespace MatchingAlgorithms
{
    [MemoryDiagnoser]
    public class AlgoritmTests
    {
        [Benchmark]
        public void TestAlgorithm()
        {
            MainAlgorithm algorithm = new MainAlgorithm();

            var result = algorithm.GetBestMatches();
        }
    }
}
