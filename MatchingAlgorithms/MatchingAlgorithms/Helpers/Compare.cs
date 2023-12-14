namespace MatchingAlgorithms;

public class Compare
{
    public List<string> CompareApps(List<Vector> installed, List<Vector> available)
    {
        var matchingWords = new List<string>();
        
        foreach (var a in installed)
        {
            foreach (var keyW in a.Keywords)
            {
                if (!matchingWords.Contains(keyW))
                {
                    matchingWords.Add(keyW);
                }
            }
        }

        return matchingWords;
    }
}