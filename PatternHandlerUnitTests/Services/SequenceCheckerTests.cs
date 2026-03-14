using PatternHandler.Services;

namespace PatternHandlerUnitTests.Services;

[TestClass]
public sealed class SequenceCheckerTests
{
    /// <summary>
    /// Test incorrect input
    /// </summary>
    [TestMethod]
    public void Test_Incorrect_Pattern()
    {
        string inputText = "Test ";
        string expectedText = "Incorrect format";

        string outputText = SequenceChecker.GetLongestSubSequence(inputText);

        Assert.AreEqual(expectedText, outputText);

    }

    /// <summary>
    /// Test one increase pattern
    /// </summary>
    [TestMethod]
    public void Test_Increase_Pattern()
    {
        string inputText = "6 1 5 9 2";
        string expectedText = "1 5 9";

        string outputText = SequenceChecker.GetLongestSubSequence(inputText);

        Assert.AreEqual(expectedText, outputText);

    }
    /// <summary>
    /// Test empty increase pattern
    /// </summary>
    [TestMethod]
    public void Test_Empty_Increase_Pattern()
    {
        string inputText = "6 5 4 3 2";
        string expectedText = "";

        string outputText = SequenceChecker.GetLongestSubSequence(inputText);

        Assert.AreEqual(expectedText, outputText);

    }

    /// <summary>
    /// Test multiple increase patterns
    /// </summary>
    [TestMethod]
    public void Test_Multiple_Increase_Patterns()
    {
        string inputText = "6 1 5 9 2 1 2 4 8 9";
        string expectedText = "1 2 4 8 9";

        string outputText = SequenceChecker.GetLongestSubSequence(inputText);

        Assert.AreEqual(expectedText, outputText);

    }

    /// <summary>
    /// Test same length increase patterns
    /// </summary>
    [TestMethod]
    public void Test_Same_Length_Increase_Patterns()
    {
        string inputText = "6 1 5 9 2 1 2 4";
        string expectedText = "1 5 9";

        string outputText = SequenceChecker.GetLongestSubSequence(inputText);

        Assert.AreEqual(expectedText, outputText);

    }

}
