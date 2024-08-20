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

        var outJson = Pingmint.Datadog.JsonSerializer.ToJsonString(model);

        Console.WriteLine(outJson);
    }

    [Test]
    public async Task Test2()
    {
        var model = new DistributionRequest
        {
            Series = new List<DistributionSeries>
            {
                new DistributionSeries
                {
                    Metric = "test.distribution",
                    Points = new List<DistributionPoint>
                    {
                        new() {
                            Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                            Value = [
                                10 + Random.Shared.NextInt64(10) - 5,
                                20 + Random.Shared.NextInt64(4) - 2,
                                50 + Random.Shared.NextInt64(20) - 10,
                                50 + Random.Shared.NextInt64(100) - 50,
                                80 + Random.Shared.NextInt64(20) - 10,
                                100 - Random.Shared.NextInt64(10),
                            ]
                        },
                    },
                }
            }
        };

        var outJson = Pingmint.Datadog.DistributionJsonSerializer.ToJsonString(model);
        Console.WriteLine(outJson);
    }
}
