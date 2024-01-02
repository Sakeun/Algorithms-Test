// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using MatchingAlgorithms;

//RandomMatches matches = new RandomMatches();
//Builders builders = new Builders();

//List<Vector> installed = builders.InstalledVectorsBuilder();
//List<Vector> available = builders.AvailableVectorsBuilder();

//var apps = matches.RandomMatch(available, installed);

//foreach (var a in apps)
//{
//    Console.WriteLine(a);
//}

//SoftCodedProbabilities probabilities = new SoftCodedProbabilities();

//probabilities.TestSoftCodedProbability(installed, available);



//MainAlgorithm algorithm = new MainAlgorithm();

//var result = algorithm.GetBestMatches();

//foreach (var r in result)
//{
//    Console.WriteLine(r);
//}

RandomizerTests tests = new RandomizerTests();
//tests.VerboseTestSteps = false;
//tests.AliasMethodTest();
//tests.SoftCodedProbabilitiesTest(10000000, 10000000);
//var summary = BenchmarkRunner.Run<AlgoritmTests>();
var summary = BenchmarkRunner.Run<RandomizerTests>();