// See https://aka.ms/new-console-template for more information
using PatternHandler.Services;

Console.WriteLine("Find the longest increasing subsequence");
string inputText = "6 1 5 9 2";
Console.WriteLine($"Input - {inputText}");

string outputText = SequenceChecker.GetLongestSubSequence(inputText);
Console.WriteLine($"OutPut - {outputText}");


//Find the longest increasing subsequence
//Input - 6 1 5 9 2
//OutPut - 1 5 9
