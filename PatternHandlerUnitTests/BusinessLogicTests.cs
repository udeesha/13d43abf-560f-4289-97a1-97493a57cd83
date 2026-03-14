using PatternHandler.Services;

namespace PatternHandlerUnitTests;

[TestClass]
public sealed class BusinessLogicTests
{
    [TestMethod]
    public void TestCaseOne()
    {
        string inputText = "6 1 5 9 2";
        string expectedText = "1 5 9";

        string outputText = SequenceChecker.GetLongestSubSequence(inputText);

        Assert.AreEqual(expectedText, outputText);

    }
}
