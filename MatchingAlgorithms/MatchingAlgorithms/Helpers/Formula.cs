namespace MatchingAlgorithms;

public class Formula
{
    public double WeightFormula(string[] words, Vector app)
    {
        int matching = app.Keywords.Count(words.Contains);

        double res = (matching * 2) / Decimal.ToDouble(app.Keywords.Length + words.Length);
        return res;
    }
}