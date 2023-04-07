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
        var serializer = SeriesJsonSerializer.SeriesRequest;

        var model = new SeriesRequest
        {
            Series = new List<Series>
            {
                new Series
                {
                    Metric = "test.metric",
                    Interval = 60,
                    Unit = "unit",
                    Resources = ModelFactory.RequiredResources(),
                    Points = new List<Point>
                    {
                        ModelFactory.CurrentPoint(123.456789m),
                    },
                }
            }
        };

        var outJson = Pingmint.Datadog.SeriesJsonSerializer.ToJsonString(model);

        Console.WriteLine(outJson);
    }
}
