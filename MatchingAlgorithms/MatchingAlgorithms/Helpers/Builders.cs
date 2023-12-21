namespace MatchingAlgorithms;

public class Builders
{
    private Formula _formula = new Formula();
    public List<Vector> InstalledVectorsBuilder()
    {
        return new List<Vector>()
        {
            new Vector { Name = "A1", Keywords = new[] { "K1", "K4", "K7" } },
            new Vector { Name = "A34", Keywords = new[] { "K3", "K6", "K7" } },
            new Vector { Name = "A19", Keywords = new[] { "K2", "K4", "K5" } },
            new Vector { Name = "A27", Keywords = new[] { "K2", "K6", "K7" } },
            new Vector { Name = "A9", Keywords = new[] { "K4", "K5", "K6" } },
        };
    }

    public List<Vector> AvailableVectorsBuilder()
    {
        return new List<Vector>
        {
            new Vector { Name = "A2", Keywords = new []{ "K2", "K3", "K6", "K7" }},
            new Vector { Name = "A3", Keywords = new []{ "K1", "K5", "K6", "K7", "K9" }},
            new Vector { Name = "A4", Keywords = new []{ "K3", "K4", "K7", "K10" }},
            new Vector { Name = "A5", Keywords = new []{ "K2", "K5", "K6", "K8", "K12" }},
            new Vector { Name = "A6", Keywords = new []{ "K1", "K6", "K11" }},
            new Vector { Name = "A7", Keywords = new []{ "K2", "K4", "K7", "K8" }},
            new Vector { Name = "A10", Keywords = new []{ "K2", "K3", "K4", "K7", "K10" }},
            new Vector { Name = "A11", Keywords = new []{ "K1", "K2", "K5", "K8" }},
            new Vector { Name = "A14", Keywords = new []{ "K2", "K5", "K7", "K10", "K12" }},
            new Vector { Name = "A15", Keywords = new []{ "K1", "K3", "K4", "K7", "K11" }},
            new Vector { Name = "A16", Keywords = new []{ "K2", "K6", "K9", "K12" }},
            new Vector { Name = "A17", Keywords = new []{ "K4", "K5", "K7", "K8", "K11" }},
            new Vector { Name = "A18", Keywords = new []{ "K11", "K13", "K16", "K19" }},
            new Vector { Name = "A20", Keywords = new []{ "K1", "K2", "K7", "K8" }},
            new Vector { Name = "A23", Keywords = new []{ "K3", "K6", "K7", "K9", "K12" }},
            new Vector { Name = "A24", Keywords = new []{ "K1", "K4", "K6", "K10" }},
            new Vector { Name = "A25", Keywords = new []{ "K2", "K5", "K7", "K8", "K11" }},
            new Vector { Name = "A26", Keywords = new []{ "K1", "K3", "K4", "K12" }},
            new Vector { Name = "A30", Keywords = new []{ "K2", "K4", "K5", "K11", "K13" }},
            new Vector { Name = "A31", Keywords = new []{ "K1", "K2", "K7", "K8" }},
            new Vector { Name = "A32", Keywords = new []{ "K8", "K10", "K31", "K13", "K12" }},
            new Vector { Name = "A36", Keywords = new []{ "K2", "K5", "K7", "K8", "K11" }},
            new Vector { Name = "A37", Keywords = new []{ "K1", "K3", "K4", "K12" }},
            new Vector { Name = "A38", Keywords = new []{ "K2", "K6", "K13" }},
            new Vector { Name = "A39", Keywords = new []{ "K4", "K5", "K7", "K10" }},
            new Vector { Name = "A40", Keywords = new []{ "K1", "K3", "K6", "K9", "K11" }},
            new Vector { Name = "A41", Keywords = new []{ "K2", "K4", "K5", "K7", "K13" }},
            new Vector { Name = "A42", Keywords = new []{ "K1", "K2", "K7", "K8" }},
            new Vector { Name = "A44", Keywords = new []{ "K10", "K11", "K13", "K14", "K12" }},
            new Vector { Name = "A45", Keywords = new []{ "K3", "K6", "K7", "K9", "K11" }},
            new Vector { Name = "A46", Keywords = new []{ "K1", "K4", "K6", "K10" }},
            new Vector { Name = "A47", Keywords = new []{ "K2", "K5", "K7", "K8", "K13" }},
            new Vector { Name = "A48", Keywords = new []{ "K1", "K3", "K4", "K12" }},
            new Vector { Name = "A49", Keywords = new []{ "K2", "K6", "K7", "K9", "K11" }},
            new Vector { Name = "A50", Keywords = new []{ "K4", "K5", "K7", "K10" }},
        };
    }

    public Dictionary<int, double> ProbabilitiesBuilder(int count)
    {
        Dictionary<int, double> result = new Dictionary<int, double>();
        List<double> probabilityList = new List<double>();

        double scale = 0.1;

        for (int i = 0; i < count; i++)
        {
            probabilityList.Add(scale * Math.Sqrt(scale));
        }

        Random random = new Random();

        result.Add(count, 0.000001);
        for (int i = 0; i < count; i++)
        {
            int randomIndex = random.Next(count);
            result.Add(i, probabilityList[randomIndex]);
        }
        return result;
    }

    public Dictionary<int, double> FixedProbabilitiesBuilder(int count)
    {
        var result = new Dictionary<int, double>();
        for (int i = 0; i < count; i++)
        {
            result.Add(i, i / 10);
        }
        return result;
    }

    public List<Edge> GetEdges()
    {
        var available = AvailableVectorsBuilder();
        var installed = InstalledVectorsBuilder();
        var returnList = new List<Edge>();

        foreach (var vector in available)
        {
            returnList.AddRange(GetAllEdges(vector, installed));
        }

        return returnList;
    }

    private List<Edge> GetAllEdges(Vector vector, List<Vector> installed)
    {
        var edges = new List<Edge>();
        foreach (var v in installed)
        {
            foreach (var keyword in vector.Keywords)
            {
                if (v.Keywords.Contains(keyword))
                {
                    edges.Add(new Edge() { Vector1 = vector.Name, Vector2 = v.Name, Weight = _formula.WeightFormula(v.Keywords.ToList(), vector) });
                    break;
                }
            }
        }

        return edges;
    }

    public List<Vector> SmallAvailableListBuilder()
    {
        return new List<Vector>()
        {
            new() { Name = "1", Keywords = new[]{"2", "3"}},
            new() { Name = "2", Keywords = new[]{"2", "3", "4"}},
            new() { Name = "3", Keywords = new[]{"1", "4", "3"}},
            new() { Name = "4", Keywords = new[]{"1", "2", "3"}},
            new() { Name = "5", Keywords = new[]{"6", "2", "7"}},
            new() { Name = "6", Keywords = new[]{"6", "8", "7"}},
        };
    }

    public List<Vector> SmallInstalledListBuilder()
    {
        return new List<Vector>()
        {
            new() { Name = "6", Keywords = new[]{"4"}},
            new() { Name = "7", Keywords = new[]{"2", "A"}},
            new() { Name = "8", Keywords = new[]{"1", "2", "A"}},
            new() { Name = "9", Keywords = new[]{"1", "A", "3", "4"}},
            new() { Name = "10", Keywords = new[]{"A", "2", "A", "4", "5"}},
        };
    }

    public List<Edge> SmallEdgeListBuilder()
    {
        var installed = SmallInstalledListBuilder();
        var available = SmallAvailableListBuilder();
        var edges = new List<Edge>();

        foreach (var vector in available)
        {
            edges.AddRange(GetAllEdges(vector, installed));
        }

        Console.WriteLine("edges: ");
        foreach (var e in edges)
        {
            Console.WriteLine($"v1: {e.Vector1}, v2: {e.Vector2}, weight: {e.Weight}");
        }

        return edges;
    }

    public List<VectorKeyword> SmallVectorKeywordsBuilder()
    {
        return new List<VectorKeyword>()
        {
            new() {App = "1", Word = "1"},
            new() {App = "1", Word = "2"},
            new() {App = "1", Word = "2"},

            new() {App = "2", Word = "2"},
            new() {App = "2", Word = "3"},
            new() {App = "2", Word = "4"},

            new() {App = "3", Word = "1"},
            new() {App = "3", Word = "4"},
            new() {App = "3", Word = "3"},

            new() {App = "4", Word = "1"},
            new() {App = "4", Word = "2"},
            new() {App = "4", Word = "3"},

            new() {App = "5", Word = "6"},
            new() {App = "5", Word = "2"},
            new() {App = "5", Word = "7"},

            new() {App = "6", Word = "6"},
            new() {App = "6", Word = "8"},
            new() {App = "6", Word = "7"},
        };
    }
}