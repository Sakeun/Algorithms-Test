namespace MatchingAlgorithms;

public class SoftCodedProbabilities
{
    #region Algorithm
    private struct Entry {
        public double accumulatedWeight;
        public string item;
    }

    private List<Entry> _entries = new List<Entry>();
    private double accumulatedWeight;
    private Random rand = new Random();

    public void AddEntry(string item, double weight) {
        accumulatedWeight += weight;
        _entries.Add(new Entry { item = item, accumulatedWeight = accumulatedWeight });
    }

    public string GetRandom() {
        var r = rand.NextDouble() * accumulatedWeight;
        foreach (Entry entry in _entries) {
            if (entry.accumulatedWeight >= r)
            {
                var curr = entry.item;
                accumulatedWeight -= entry.accumulatedWeight;
                _entries.RemoveAll(e => e.item == curr);
                return curr;
            }
        }
        return default;
    }
    #endregion

    #region Test

    public void TestSoftCodedProbability(List<Vector> installed, List<Vector> available)
    {
        var compare = new Compare();
        var form = new Formula();
        var keywords = compare.GetIntalledKeywords(installed);
        
        foreach (var a in available)
        {
            if (!compare.HasKeywords(keywords, a)) continue;
            
            var result = form.WeightFormula(keywords, a);
            Console.WriteLine($"Vector: {a.Name}, Weight: {result}");
        }

        Dictionary<string, int> found = new Dictionary<string, int>();

        for (var i = 1; i <= 20; i++)
        {
            Reset();
            foreach (var a in available)
            {
                if (compare.HasKeywords(keywords, a))
                {
                    var result = form.WeightFormula(keywords, a);

                    AddEntry(a.Name, result);
                }
            }

            // Get 3 random numbers and add the count of appearances to the array
            var i1 = GetRandom();
            if (!found.ContainsKey(i1))
                found.Add(i1, 0);
            found[i1]++;

            var i2 = GetRandom();
            if (!found.ContainsKey(i2))
                found.Add(i2, 0);
            found[i2]++;

            var i3 = GetRandom();
            if (!found.ContainsKey(i3))
                found.Add(i3, 0);
            found[i3]++;

            Console.WriteLine($"Round {i}: {i1}, {i2}, {i3}");
        }

        var amount = found.GroupBy(x => x.Value)
            .OrderByDescending(y => y.Key);
        
        foreach (var v in amount)
        {
            var str = $"{v.Key}x: ";
            str = v.Aggregate(str, (current, f) => current + $"{f.Key} ");
            
            Console.WriteLine(str);
        }
    }
    private void Reset()
    {
        _entries.Clear();
        accumulatedWeight = 0;
    }

    #endregion
}