namespace MatchingAlgorithms.Algorithms
{
    public class AliasMethod
    {
        private readonly Random random;
        private readonly int[] appIds;
        private readonly Dictionary<int, int> alias;
        private readonly Dictionary<int, double> probabilities;

        public AliasMethod(Dictionary<int, double> inputProbabilities)
        {
            if (!InputProbabilitiesIsValid(inputProbabilities))
            {
                throw new ArgumentException("inputProbabilities not valid");
            }

            probabilities = new Dictionary<int, double>();
            alias = new Dictionary<int, int>();

            appIds = inputProbabilities.Keys.ToArray();
            random = new Random();

            inputProbabilities = NormalizeInputProbabilities(inputProbabilities);

            BuildAliasTable(inputProbabilities);
        }

        public int NextAppId()
        {
            int column = random.Next(probabilities.Keys.Count);

            bool coinToss = random.NextDouble() < probabilities[appIds[column]];

            if (coinToss)
            {
                return appIds[column];
            }
            return alias[appIds[column]];
        }

        private bool InputProbabilitiesIsValid(Dictionary<int, double> inputProbabilities)
        {
            return inputProbabilities != null && inputProbabilities.Count > 0;
        }

        private Dictionary<int, double> NormalizeInputProbabilities(Dictionary<int, double> inputProbabilities)
        {
            double sum = inputProbabilities.Values.Sum();

            if (sum.Equals(1.0))
            {
                return inputProbabilities;
            }

            foreach (var key in inputProbabilities.Keys.ToList())
            {
                inputProbabilities[key] /= sum;
            }
            return inputProbabilities;
        }

        private void BuildAliasTable(Dictionary<int, double> inputProbabilities)
        {
            Stack<int> small = new Stack<int>();
            Stack<int> large = new Stack<int>();
            double average = 1.0 / inputProbabilities.Count;

            ConstructStacks(small, large, inputProbabilities, average);
            PairAliases(small, large, inputProbabilities, average);
            SetRemainingProbabilities(small, large);
        }

        private void ConstructStacks(Stack<int> small, Stack<int> large, Dictionary<int, double> inputProbabilities, double average)
        {
            foreach (KeyValuePair<int, double> probability in inputProbabilities)
            {
                if (probability.Value >= average)
                {
                    large.Push(probability.Key);
                } else
                {
                    small.Push(probability.Key);
                }
            }
        }

        private void PairAliases(Stack<int> small, Stack<int> large, Dictionary<int, double> inputProbabilities, double average)
        {
            while (small.Count > 0 && large.Count > 0)
            {
                int less = small.Pop();
                int more = large.Pop();

                probabilities[less] = inputProbabilities[less] * inputProbabilities.Count;
                alias[less] = more;

                inputProbabilities[more] = (inputProbabilities[more] + inputProbabilities[less]) - average;

                if (inputProbabilities[more] >= average)
                {
                    large.Push(more);
                } else
                {
                    small.Push(more);
                }
            }
        }

        private void SetRemainingProbabilities(Stack<int> small, Stack<int> large)
        {
            while (small.Count > 0)
            {
                int key = small.Pop();
                probabilities[key] = 1.0;
            }

            while (large.Count > 0)
            {
                int key = large.Pop();
                probabilities[key] = 1.0;
            }
        }
    }
}
