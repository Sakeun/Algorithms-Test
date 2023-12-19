namespace MatchingAlgorithms;

public class Builders
{
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
        //result.Add(0, 0.2);
        //result.Add(1, 0.2);
        //result.Add(2, 0.4);
        //result.Add(3, 0.3);
        //result.Add(4, 0.1);
        //result.Add(5, 0);
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

}