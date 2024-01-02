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
            // Stopwatch stopwatch = new Stopwatch();
            //if (probabilities == null)
            //{
            ConstructProbabilities(amountOfApps);
            if (VerboseTestSteps)
            {
                Console.WriteLine("probabilities build");
            }
            //}

            //stopwatch.Start();
            AliasMethod aliasMethod = new AliasMethod(probabilities);
            //stopwatch.Stop();

            //Console.WriteLine($"Construction completed in {stopwatch.ElapsedMilliseconds} ms");

            Dictionary<int, int> NumberCount = new Dictionary<int, int>();

            //stopwatch.Restart();

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

            //stopwatch.Stop();
            if (VerboseTestSteps)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Kansen:");
                foreach (var number in NumberCount.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"{number.Key}: {probabilities[number.Key]}");
                }

                Console.WriteLine("-------------------------------------");
                foreach (KeyValuePair<int, int> number in NumberCount.OrderBy(x => x.Key))
                {
                    if (number.Key < 10)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine($"{number.Key}: {number.Value} keer");
                }
            }
            Console.WriteLine("-------------------------------------");
            //Console.WriteLine($"Number generation completed in {stopwatch.ElapsedMilliseconds} ms");
        }
        [Benchmark]
        public void SoftCodedProbabilitiesTest()
        {
            //Stopwatch stopwatch = new Stopwatch();
            SoftCodedProbabilities softCodedProbabilities = new SoftCodedProbabilities();
            //if (probabilities == null)
            //{
            ConstructProbabilities(amountOfApps);
            //if (VerboseTestSteps)
            //{
            //  Console.WriteLine("probabilities build");
            //}
            //}

            foreach (var probability in probabilities)
            {
                softCodedProbabilities.AddEntry(probability.Key.ToString(), probability.Value);
            }

            //stopwatch.Stop();
            //Console.WriteLine($"Construction completed in {stopwatch.ElapsedMilliseconds} ms");
            List<string> results = new List<string>();
            //stopwatch.Restart();
            for (int i = 0; i < amountOfRecommendations; i++)
            {
                results.Add(softCodedProbabilities.GetRandom());
            }
            //stopwatch.Stop();
            //Console.WriteLine("-------------------------------------");
            //Console.WriteLine($"Number generation completed in {stopwatch.ElapsedMilliseconds} ms");
        }

        private void ConstructProbabilities(int amountOfApps)
        {
            probabilities = builder.FixedProbabilitiesBuilder(amountOfApps);
            //probabilities = builder.ProbabilitiesBuilder(amountOfApps);
        }
    }
}
