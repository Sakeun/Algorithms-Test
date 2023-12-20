// See https://aka.ms/new-console-template for more information

using MatchingAlgorithms;
using MatchingAlgorithms.Algorithms;
using System.Diagnostics;

//RandomMatches matches = new RandomMatches();
Builders builders = new Builders();

//List<Vector> installed = builders.InstalledVectorsBuilder();
//List<Vector> available = builders.AvailableVectorsBuilder();

//var apps = matches.RandomMatch(available, installed);

//foreach (var a in apps)
//{
//    Console.WriteLine(a);
//}

//SoftCodedProbabilities probabilities = new SoftCodedProbabilities();

//probabilities.TestSoftCodedProbability(installed, available);



//---------------------------------------------------------------------------
//Alias method test code
//---------------------------------------------------------------------------
Stopwatch stopwatch = new Stopwatch();
Dictionary<int, double> probabilities = builders.ProbabilitiesBuilder(5);
Console.WriteLine("probabilities build");

stopwatch.Start();
AliasMethod aliasMethod = new AliasMethod(probabilities);
stopwatch.Stop();

Console.WriteLine($"Construction completed in {stopwatch.ElapsedMilliseconds} ms");
Dictionary<int, int> NumberCount = new Dictionary<int, int>();

stopwatch.Restart();

for (int i = 0; i < 5; i++)
{
    int randomIndex = aliasMethod.NextAppId();
    if (NumberCount.ContainsKey(randomIndex))
    {
        NumberCount[randomIndex]++;
    } else
    {
        NumberCount.Add(randomIndex, 1);
    }
}

stopwatch.Stop();

//Console.WriteLine("-------------------------------------");
//Console.WriteLine("Kansen:");
//foreach (var number in NumberCount.OrderBy(x => x.Key))
//{
//    Console.WriteLine($"{number.Key}: {probabilities[number.Key]}");
//}

//Console.WriteLine("-------------------------------------");
//foreach (KeyValuePair<int, int> number in NumberCount.OrderBy(x => x.Key))
//{
//    if (number.Key < 10)
//    {
//        Console.Write(" ");
//    }
//    Console.WriteLine($"{number.Key}: {number.Value} keer");
//}

Console.WriteLine("-------------------------------------");
Console.WriteLine($"Number generation completed in {stopwatch.ElapsedMilliseconds} ms");

MainAlgorithm algorithm = new MainAlgorithm();

var result = algorithm.GetBestMatches();

foreach (var r in result)
{
    Console.WriteLine(r);
}
