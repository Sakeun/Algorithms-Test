namespace MatchingAlgorithms;

public class Formula
{
    public double WeightFormula(List<string> words, Vector app)
    {
        int matching = app.Keywords.Count(words.Contains);

        double res = (matching * 2) / Decimal.ToDouble(app.Keywords.Length + words.Count);
        return res;
    }
}