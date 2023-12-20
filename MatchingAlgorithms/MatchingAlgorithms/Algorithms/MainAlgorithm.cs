namespace MatchingAlgorithms;

public class MainAlgorithm
{
    private const int _recommendedCount = 3;
    private const double _matchDepthCutoff = 0.5;
    private const int _topKeywordsAmount = 5;

    private readonly Builders _builders = new Builders();
    private readonly SoftCodedProbabilities _randomizer = new SoftCodedProbabilities();
    
    public List<string> GetBestMatches()
    {
        var installed = _builders.SmallInstalledListBuilder(); // Change to DB query getting the desired apps
        if (installed.Count == 0)
        {
            return GetTopInstalled();
        }

        var matches = _builders.SmallEdgeListBuilder();
        
        var recommended = new List<string>();

        if(matches.Count >= _recommendedCount)
        {
            var matchesWithWeight = CalculateTopMatching(installed, matches);
            if (matchesWithWeight.Count > 3)
            {
                recommended = GetRandomRecommended(matchesWithWeight, _recommendedCount);
            }
        }
        else
        {
            recommended.AddRange(matches.Select(x => x.Vector1));
            // In production this BFS is done using all edges with a weight above the matchDepthCutoff
            // Example SQL Query: SELECT * FROM Edges WHERE weight > _matchDepthCutoff
            var furtherRecommended = RecommendedBfs(recommended, matches);
            recommended.AddRange(GetRandomRecommended(furtherRecommended, _recommendedCount - recommended.Count));
        }
        
        return recommended;
    }

    /// <summary>
    /// This function checks the best matching vectors based on the top 5 most common keywords
    /// 
    /// In reality this would query the database to get all matches, but for this test, an object is made
    /// which is a mock of the what it'd be like in the real database.
    /// </summary>
    /// <param name="installed">list of the installed apps</param>
    /// <param name="matches">list of the matched apps</param>
    /// <returns>A list of all matching apps with the new weight</returns>
    private List<Edge> CalculateTopMatching(List<Vector> installed, List<Edge> matches)
    {
        var topKeywords = GetTop5(installed);
        var vectorkeywordtable = _builders.SmallVectorKeywordsBuilder();
        var currentTop = 0.1;
        foreach (var keyword in topKeywords)
        {
            foreach (var vk in vectorkeywordtable.Where(x => x.Word == keyword.Key).Select(vk => vk.App))
            {
                foreach (var match in matches.Where(x => x.Vector1 == vk || x.Vector2 == vk))
                {
                    match.Weight += currentTop;
                }
            }

            currentTop += 0.1;
        }
        return matches;

    }

    private List<Edge> RecommendedBfs(List<string> recommended, List<Edge> edges)
    {
        var queue = new Queue<string>();
        var recommendedEdges = new List<Edge>();
        recommended.ForEach(x => queue.Enqueue(x));
        
        while(recommended.Count < 3)
        {
            var curr = queue.Dequeue();
            foreach (var edge in edges)
            {
                if (edge.Vector1 == curr || edge.Vector2 == curr)
                {
                    recommendedEdges.Add(edge);
                    queue.Enqueue(edge.Vector1 == curr ? edge.Vector1 : edge.Vector2);
                }
            }
        }

        return recommendedEdges;
    }

    private Dictionary<string, int> GetTop5(List<Vector> installed)
    {
        var topKeywords = new Dictionary<string, int>();
        foreach (var keyword in installed.SelectMany(vector => vector.Keywords))
        {
            if (!topKeywords.TryAdd(keyword, 1))
                topKeywords[keyword]++;

            if (topKeywords.Count != _topKeywordsAmount) 
                continue;
            
            topKeywords = topKeywords.OrderByDescending(x => x.Value).ToDictionary();
            break;
        }

        return topKeywords;
    }

    private List<string> GetRandomRecommended(List<Edge> vectors, int amountToRecommend)
    {
        foreach (var vector in vectors)
        {
            _randomizer.AddEntry(vector.Vector1, vector.Weight);
        }

        var apps = new List<string>();
        for (var i = 0; i < amountToRecommend; i++)
        {
            apps.Add(_randomizer.GetRandom());
        }

        return apps;
    }

    
    /// <summary>
    /// Should return a list of top installed apps from the Database
    /// </summary>
    /// <returns></returns>
    private List<string> GetTopInstalled()
    {
        return new List<string>();
    }
}