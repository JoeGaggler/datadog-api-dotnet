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
        var serializer = Pingmint.Datadog.SeriesJsonSerializer.SeriesRequest;

        var model = new Pingmint.Datadog.SeriesRequest
        {
            Series = new List<Pingmint.Datadog.Series>
            {
                new Pingmint.Datadog.Series
                {
                    Metric = "test.metric",
                    Interval = 60,
                    Unit = "unit",
                    Resources = new List<Pingmint.Datadog.Resource>
                    {
                        new() { Type = "blah", Name = "name" }
                    },
                    Points = new List<Pingmint.Datadog.Point>
                    {
                        new Pingmint.Datadog.Point
                        {
                            Timestamp = 1234567890,
                            Value = 123.456789m
                        }
                    },
                }
            }
        };

        var outJson = Pingmint.Datadog.SeriesJsonSerializer.ToJsonString(model);

        Console.WriteLine(outJson);
    }
}
