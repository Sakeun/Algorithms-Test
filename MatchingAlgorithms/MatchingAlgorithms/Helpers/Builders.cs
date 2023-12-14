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
            new Vector { Name = "A2", Keywords = new[] { "K2", "K3", "K6", "K7" } },
            new Vector { Name = "A3", Keywords = new[] { "K1", "K5", "K6", "K7" } },
            new Vector { Name = "A4", Keywords = new[] { "K3", "K4", "K7" } },
            new Vector { Name = "A5", Keywords = new[] { "K2", "K5", "K6" } },
            new Vector { Name = "A6", Keywords = new[] { "K1", "K6" } },
            new Vector { Name = "A7", Keywords = new[] { "K2", "K4", "K7" } },
            new Vector { Name = "A8", Keywords = new[] { "K1", "K3", "K5" } },
            new Vector { Name = "A10", Keywords = new[] { "K2", "K3", "K4", "K7" } },
            new Vector { Name = "A11", Keywords = new[] { "K1", "K2", "K5" } },
            new Vector { Name = "A12", Keywords = new[] { "K3", "K6", "K7" } },
            new Vector { Name = "A13", Keywords = new[] { "K1", "K4", "K6" } },
            new Vector { Name = "A14", Keywords = new[] { "K2", "K5", "K7" } },
            new Vector { Name = "A15", Keywords = new[] { "K1", "K3", "K4", "K7" } },
            new Vector { Name = "A16", Keywords = new[] { "K2", "K6" } },
            new Vector { Name = "A17", Keywords = new[] { "K4", "K5", "K7" } },
            new Vector { Name = "A18", Keywords = new[] { "K1", "K3", "K6" } },
            new Vector { Name = "A20", Keywords = new[] { "K1", "K2", "K7" } },
            new Vector { Name = "A21", Keywords = new[] { "K3", "K5", "K6" } },
            new Vector { Name = "A22", Keywords = new[] { "K1", "K2", "K4" } },
            new Vector { Name = "A23", Keywords = new[] { "K3", "K6", "K7" } },
            new Vector { Name = "A24", Keywords = new[] { "K1", "K4", "K6" } },
            new Vector { Name = "A25", Keywords = new[] { "K2", "K5", "K7" } },
            new Vector { Name = "A26", Keywords = new[] { "K1", "K3", "K4" } },
            new Vector { Name = "A28", Keywords = new[] { "K4", "K5", "K7" } },
            new Vector { Name = "A29", Keywords = new[] { "K1", "K3", "K6" } },
            new Vector { Name = "A30", Keywords = new[] { "K2", "K4", "K5" } },
            new Vector { Name = "A31", Keywords = new[] { "K1", "K2", "K7" } },
            new Vector { Name = "A32", Keywords = new[] { "K3", "K5", "K6", "K7" } },
            new Vector { Name = "A33", Keywords = new[] { "K1", "K2", "K4" } },
            new Vector { Name = "A35", Keywords = new[] { "K1", "K4", "K6" } },
            new Vector { Name = "A36", Keywords = new[] { "K2", "K5", "K7" } },
            new Vector { Name = "A37", Keywords = new[] { "K1", "K3", "K4" } },
            new Vector { Name = "A38", Keywords = new[] { "K2", "K6" } },
            new Vector { Name = "A39", Keywords = new[] { "K4", "K5", "K7" } },
            new Vector { Name = "A40", Keywords = new[] { "K1", "K3", "K6" } },
            new Vector { Name = "A41", Keywords = new[] { "K2", "K4", "K5", "K7" } },
            new Vector { Name = "A42", Keywords = new[] { "K1", "K2", "K7" } },
            new Vector { Name = "A43", Keywords = new[] { "K3", "K5", "K6" } },
            new Vector { Name = "A44", Keywords = new[] { "K1", "K2", "K4" } },
            new Vector { Name = "A45", Keywords = new[] { "K3", "K6", "K7" } },
            new Vector { Name = "A46", Keywords = new[] { "K1", "K4", "K6" } },
            new Vector { Name = "A47", Keywords = new[] { "K2", "K5", "K7" } },
            new Vector { Name = "A48", Keywords = new[] { "K1", "K3", "K4" } },
            new Vector { Name = "A49", Keywords = new[] { "K2", "K6", "K7" } },
            new Vector { Name = "A50", Keywords = new[] { "K4", "K5", "K7" } },
        };
    }

}