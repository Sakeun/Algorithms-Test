using BenchmarkDotNet.Attributes;
using MatchingAlgorithms.Algorithms;

namespace MatchingAlgorithms
{
    [MemoryDiagnoser]
    public class RandomizerTests
    {
        public bool VerboseTestSteps { get; set; } = false;
        private int amountOfApps = 100;
        private int amountOfRecommendations = 100000;

        private Dictionary<int, double> probabilities;
        private Builders builder = new Builders();

        [Benchmark]
        public void AliasMethodTest()
        {
            ConstructProbabilities(amountOfApps);
            if (VerboseTestSteps)
            {
                Console.WriteLine("probabilities build");
            }

            AliasMethod aliasMethod = new AliasMethod(probabilities);

            Dictionary<int, int> NumberCount = new Dictionary<int, int>();

            for (int i = 0; i < amountOfRecommendations; i++)
            {
                int randomIndex = aliasMethod.NextAppId();
                if (NumberCount.ContainsKey(randomIndex))
                {
                    NumberCount[randomIndex]++;
                } else
                {
                    NumberCount.Add(randomIndex, 1);
                }
            }
        }

        [Benchmark]
        public void SoftCodedProbabilitiesTest()
        {
            SoftCodedProbabilities softCodedProbabilities = new SoftCodedProbabilities();

            ConstructProbabilities(amountOfApps);

            foreach (var probability in probabilities)
            {
                softCodedProbabilities.AddEntry(probability.Key.ToString(), probability.Value);
            }

            List<string> results = new List<string>();

            for (int i = 0; i < amountOfRecommendations; i++)
            {
                results.Add(softCodedProbabilities.GetRandom());
            }
        }

        private void ConstructProbabilities(int amountOfApps)
        {
            probabilities = builder.ProbabilitiesBuilder(amountOfApps);
        }
    }
}
