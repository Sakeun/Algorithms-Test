namespace MatchingAlgorithms;

public class Compare
{
    public List<string> GetIntalledKeywords(List<Vector> installed)
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

    // Check if Vector keywords is in list of keywords
    public bool HasKeywords(List<string> keywords, Vector app)
    {
        return app.Keywords.Any(kw => keywords.Contains(kw));
    }
}