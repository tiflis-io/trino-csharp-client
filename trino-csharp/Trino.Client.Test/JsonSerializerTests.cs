using Newtonsoft.Json;
using Trino.Client.Utils;

namespace Trino.Client.Test;

[TestClass]
public class JsonSerializerTests
{
    [TestMethod]
    public void TestTimestampConversion()
    {
        var json = """
                   {
                        "progressPercentage": "NaN",
                        "nodes": 4
                   }
                   """;

        var stats = JsonConvert.DeserializeObject<Trino.Client.Model.StatementV1.TrinoStats>(json,
            DefaultJsonSerializerOptions.Instance);

        Assert.AreEqual(4, stats!.nodes);
        Assert.AreEqual(0, stats!.progressPercentage);
    }
}