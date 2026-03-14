using System;
using System.Collections.Generic;
using PatternHandler.Helper;

namespace PatternHandler.Services;

/// <summary>
/// This class contains a method to find longest incremental sub sequence from given number sequence
/// </summary>
public static class SequenceChecker
{

    //Set input numbers delimiter
    private const string DELIMITER = " ";

    /// <summary>
    /// Finds the longest increasing subsequence (increased by any number) present in given sequence
    /// If more than 1 sequence exists with the longest length, return the earliest sequence
    /// </summary>
    /// <param name="inputText">Accept string with numbers and spaces</param>
    /// <returns>
    /// Valid input -> longest increamental sequence
    /// Incorrect input -> "Incorrect format"       
    /// </returns>
    public static string GetLongestSubSequence(string inputText)
    {
        //Return error code for incorrect format of input string
        if (!Utility.IsValidInput(inputText))
        {
            return "Incorrect format";
        }
        //Converts string list into int list
        IEnumerable<int> itemList = Utility.GetNumberList(inputText, DELIMITER);
        var enumerator = itemList.GetEnumerator();

        //Move to fisrt record and get first element/number as previousNumber
        enumerator.MoveNext();
        int previousNumber = enumerator.Current; // Placeholder to store previous number while comparing number pairs in sequence loop

        List<int> longestSequence = new List<int>(); //Placeholder to store the longest incremental sequence list. 
        List<int> tempSequence = new List<int>(); //Placeholder to keep and append incremental sequence list while looping through the complete list

        //looping through the list from second element onwards
        while (enumerator.MoveNext())
        {
            //If current number pair is an incremental sequence, it will be added into tempSequence list until current pair is not an incremental pair 
            if (previousNumber < enumerator.Current)
                Utility.AddNumberToTempSequence(tempSequence, previousNumber, enumerator.Current);
            //When current pair is not an increamental pair, it will check tempSequence list and add that into longestSequence list. If tempSequence list is empty, it will move to next pair
            else
                longestSequence = AddLongestSequence(tempSequence, longestSequence);

            //Update current number as previous number to compare with next number from main sequence
            previousNumber = enumerator.Current;
        }
        //Check and add if there is a longest sequence at the end of the list (including the last item. Need to check this outside the loop as last iteration is not checking that)
        longestSequence = AddLongestSequence(tempSequence, longestSequence);

        //Returns the longest sequence as a string
        return string.Join(" ", longestSequence);

    }

    /// <summary>
    /// Check given temp increasing sequence against stored longest sequence and update it if temp on is longer that stored one
    /// </summary>
    /// <param name="tempSequence">Reference to temp sequence list</param>
    /// <param name="longestSequence">Reference to longest sequece list</param>
    /// <returns>longestSequence</returns>
    private static List<int> AddLongestSequence(List<int> tempSequence, List<int> longestSequence)
    {
        if (tempSequence.Count > 1)
        {
            //Check and update longest sequence list
            longestSequence = Utility.CompareSequences(tempSequence, longestSequence);

            //Clear items from tempSequence list to start appending values for  next incremental sequence
            tempSequence.Clear();
        }
        return longestSequence;
    }
}
