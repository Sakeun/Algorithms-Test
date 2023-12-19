namespace MatchingAlgorithms.Algorithms
{
    /// <summary>
    /// Implementatie van Vose's Alias Method. Let op algoritme vereist een som van kansen van 1.0
    /// </summary>
    public class AliasMethod
    {
        private readonly Random random;

        private readonly int[] appIds;
        private readonly int[] alias;
        private readonly double[] probabilities;

        public AliasMethod(Dictionary<int, double> inputProbabilities)
        {
            if (!InputProbabilitiesIsValid(inputProbabilities))
            {
                throw new ArgumentException("inputProbabilities not valid");
            }

            appIds = inputProbabilities.Keys.ToArray();
            random = new Random();
            probabilities = new double[inputProbabilities.Count];
            alias = new int[inputProbabilities.Count];

            inputProbabilities = NormalizeInputProbabilities(inputProbabilities);

            BuildAliasTables(inputProbabilities);
        }

        public int NextAppId()
        {
            int column = random.Next(probabilities.Length);

            bool coinToss = random.NextDouble() < probabilities[column];

            if (coinToss)
            {
                return appIds[column];
            }
            return alias[column];
        }

        private bool InputProbabilitiesIsValid(Dictionary<int, double> inputProbabilities)
        {
            if (inputProbabilities == null)
            {
                return false;
            }

            if (inputProbabilities.Count == 0)
            {
                return false;
            }

            return true;
        }

        private Dictionary<int, double> NormalizeInputProbabilities(Dictionary<int, double> inputProbabilities)
        {
            double sum = inputProbabilities.Values.Sum();

            if (sum == 1.0)
            {
                return inputProbabilities;
            }

            foreach (var key in inputProbabilities.Keys.ToList())
            {
                inputProbabilities[key] /= sum;
            }

            return inputProbabilities;
        }

        private void BuildAliasTables(Dictionary<int, double> inputProbabilities)
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
                probabilities[small.Pop()] = 1.0;
            }

            while (large.Count > 0)
            {
                probabilities[large.Pop()] = 1.0;
            }
        }
    }
}
