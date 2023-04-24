# Pingmint.Datadog

A dotnet library that consumes the [Datadog API](https://docs.datadoghq.com/api/latest).

# Preamble

Datadog provides official libraries for dotnet, including [DogStatsD](https://github.com/DataDog/dogstatsd-csharp-client) for metrics. Prefer to use the official libraries where possible.

This library submits metrics directly to the [Series API](https://docs.datadoghq.com/api/latest/metrics/#submit-metrics) in environments where StatsD is not available, for example where UDP traffic is blocked.
