namespace MatchingAlgorithms;

public class VectorProcessor
{
    private readonly Random _random = new Random();

    public Vector GetWeightedRandomVector(Vector[] firstArray, Vector[] secondArray)
    {
        var weights = secondArray.Select(secondVector =>
            firstArray.Sum(firstVector =>
                firstVector.Keywords.Intersect(secondVector.Keywords).Count())).ToArray();

        var validVectors = secondArray.Where((secondVector, index) => weights[index] > 0).ToArray();

        if (validVectors.Length == 0)
        {
            return null;
        }

        // Calculate probabilities based on weights
        var probabilities = weights.Select(weight => (double)weight / weights.Sum()).ToArray();
            
        // Select a random vector from the filtered valid vectors with weighted probability
        var randomValue = _random.Next(0, 3);
        var cumulativeProbability = 0.0;

        for (var i = 0; i < validVectors.Length; i++)
        {
            cumulativeProbability += probabilities[i];

            if (randomValue < cumulativeProbability)
            {
                return validVectors[i];
            }
        }
        // This should not happen, but return null to handle any edge case
        return null;
    }
}
    