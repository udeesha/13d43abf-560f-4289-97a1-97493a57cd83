using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace PatternHandler.Helper;

/// <summary>
/// Provides spporting methods for SequenceChecker class
/// </summary>
public static class Utility
{
    /// <summary>
    /// Check the format of the input text. Accept only numbers and spaces. Multiple spaces are accepted
    /// </summary>
    /// <param name="inputText">Eg:- 5 6 1 6</param>
    /// <returns>True- only numbers and spaces are found, else returns false</returns>
    public static bool IsValidInput(string inputText)
    {
        string regexFormat = @"(\s*[0-9]+)+";
        return Regex.Match(inputText, regexFormat).Success;
    }

    /// <summary>
    /// Converts space delimited number string into an IEnumerable int list 
    /// </summary>
    /// <param name="inputText">Eg:- 5 6 1 6</param>
    /// <returns>IEnumerable int list</returns>
    public static IEnumerable<int> GetNumberList(string inputText, string delimeter)
    {
        return Array.ConvertAll(inputText.Split(delimeter, StringSplitOptions.RemoveEmptyEntries), s => int.Parse(s));
    }

    /// <summary>
    /// Add given int values into temp sequence list. It will add previousNumber only for empty sequence list and add currentNumber all the time
    /// </summary>
    /// <param name="sequence">Accept reference to sequence list</param>
    /// <param name="previousNumber">Previous mumber in pair</param>
    /// <param name="currentNumber">next number in the pair</param>
    /// <returns>Returns reference for updated sequence list</returns>
    public static List<int> AddNumberToTempSequence(List<int> sequence, int previousNumber, int currentNumber)
    {
        if (sequence.Count == 0)
            sequence.Add(previousNumber);

        sequence.Add(currentNumber);

        return sequence;
    }


    /// <summary>
    /// Compare tempSequence list with sequence list. Always returns the longest sequence list 
    /// </summary>
    /// <param name="tempSequence">Reference to temp sequence list</param>
    /// <param name="longestSequence">Reference to longest sequece list</param>
    /// <returns>Returns reference for updated sequence list</returns>
    public static List<int> CompareSequences(List<int> tempSequence, List<int> sequence)
    {
        //Add tempSequence items into sequence when sequence is empty
        if (sequence.Count == 0)
        {
            sequence.AddRange(tempSequence);
        }
        //compare tempSequence with existing sequence and only update if it is longer that existing one
        else if (sequence.Count < tempSequence.Count)
        {
            sequence.Clear();
            sequence.AddRange(tempSequence);
        }

        return sequence;
    }
}
