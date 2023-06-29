using System.Text;
using System.Text.Json;

namespace test;

public class UnitTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var model = new SeriesRequest
        {
            Series = new List<Series>
            {
                new Series
                {
                    Metric = "test.metric",
                    Interval = 60,
                    Unit = "unit",
                    Resources = new List<Resource>
                    {
                        new() { Type = "type1", Name = "name1" },
                        new() { Type = "type2", Name = "name2" },
                    },
                    Points = new List<Point>
                    {
                        ModelFactory.CurrentPoint(123.456789m),
                    },
                    Tags = new List<String>
                    {
                        "tag1",
                        "tag2",
                    },
                }
            }
        };

        var outJson = Pingmint.Datadog.SeriesJsonSerializer.ToJsonString(model);

        Console.WriteLine(outJson);
    }
}
