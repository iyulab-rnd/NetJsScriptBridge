namespace NetJsScriptBridge.Tests
{
    public class NetJsScriptBridgeTests
    {
        [Fact]
        public void ParseDateTimeTest()
        {
            // Define script to test
            var script = "new Date(Date.now() - 7 * 24 * 60 * 60 * 1000)";

            // Execute script and parse the date
            DateTime parsedDate = JsScriptParser.ParseDateTime(script);

            // Subtract 7 days from the current date for comparison
            DateTime expectedDate = DateTime.UtcNow.AddDays(-7);

            // Check if the difference between the two dates is within 1 minute
            Assert.True((expectedDate - parsedDate).Duration().TotalMinutes < 1, "The parsed date should be within 1 minute of the expected date.");
        }
    }
}
