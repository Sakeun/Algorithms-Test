// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using MatchingAlgorithms;

var summaryAlgorithms = BenchmarkRunner.Run<AlgoritmTests>();
var summaryRandomizer = BenchmarkRunner.Run<RandomizerTests>();