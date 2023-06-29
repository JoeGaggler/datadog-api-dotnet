# Pingmint.Datadog

A dotnet library that consumes the [Datadog API](https://docs.datadoghq.com/api/latest).

# Preamble

Note that Datadog provides official libraries for dotnet, including [DogStatsD](https://github.com/DataDog/dogstatsd-csharp-client) for metrics. You should prefer to use the official libraries where possible.

This library submits metrics directly to the [Series API](https://docs.datadoghq.com/api/latest/metrics/#submit-metrics) in environments where StatsD is not available, for example where UDP traffic is blocked.

# Getting started

Add the `Pingmint.Datadog` NuGet package to your project.

Create a `SeriesRequest` with data points and metadata:

```csharp
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
                ModelFactory.CurrentPoint(123.4m),
                ModelFactory.CurrentPoint(234.5m),
                ModelFactory.CurrentPoint(345.6m),
            },
            Tags = new List<String>
            {
                "tag1",
                "tag2",
            },
        }
    }
};
```

Create and send an HTTP request with the data:
```csharp
var ddApiKey = "your_secret_here";
using var request = Pingmint.Datadog.Http.CreateHttpRequest(model, ddApiKey);
using var response = await http.SendAsync(request);
```
