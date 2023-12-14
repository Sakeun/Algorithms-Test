// See https://aka.ms/new-console-template for more information

using MatchingAlgorithms;

RandomMatches matches = new RandomMatches();
Builders builders = new Builders();

List<Vector> installed = builders.InstalledVectorsBuilder();
List<Vector> available = builders.AvailableVectorsBuilder();

var apps = matches.RandomMatch(available, installed);

foreach (var a in apps)
{
    Console.WriteLine(a);
}