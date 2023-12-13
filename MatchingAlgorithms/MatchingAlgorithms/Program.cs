// See https://aka.ms/new-console-template for more information

using MatchingAlgorithms;

RandomMatches matches = new RandomMatches();

Vector[] installed =
{
    new Vector(){Name = "A1", Keywords = new []{"K1", "K3"}},
    new Vector(){Name = "A2", Keywords = new []{"K1", "K3"}},
    new Vector(){Name = "A3", Keywords = new []{"K1", "K4"}},
    new Vector(){Name = "A4", Keywords = new []{"K1", "K4"}},
    new Vector(){Name = "A5", Keywords = new []{"K2", "K4"}}
};

Vector[] others =
{
    new Vector(){Name = "A6", Keywords = new []{"K1", "K6"}},
    new Vector(){Name = "A7", Keywords = new []{"K8", "K6"}},
    new Vector(){Name = "A8", Keywords = new []{"K1", "K3"}},
    new Vector(){Name = "A9", Keywords = new []{"K2", "K4"}},
    new Vector(){Name = "A10", Keywords = new []{"K7", "K6"}},
    new Vector(){Name = "A11", Keywords = new []{"K4", "K6"}},
    new Vector(){Name = "A12", Keywords = new []{"K2", "K1"}},
    new Vector(){Name = "A13", Keywords = new []{"K4", "K1"}},
    new Vector(){Name = "A14", Keywords = new []{"K8", "K9"}},
};

var apps = matches.RandomMatch(others, installed);

foreach (var a in apps)
{
    Console.WriteLine(a);
}