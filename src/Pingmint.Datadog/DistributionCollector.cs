namespace Pingmint.Datadog;

public class DistributionCollector
{
    private readonly Object lockObject = new();
    private readonly List<String> sharedTags;
    private List<DistributionSeries> series = new();

    public DistributionCollector(List<String> sharedTags)
    {
        this.sharedTags = sharedTags;
    }

    public void Add(String metric, List<String> tags, DistributionPoint point)
    {
        lock (lockObject)
        {
            // This performs a linear search of the list of series when tags are used, but the list is expected to be small.
            DistributionSeries? seriesToUpdate = null;
            foreach (var candidateSeries in series)
            {
                if (candidateSeries.Metric != metric) { continue; }
                if (candidateSeries.Tags is not { } candidateTags || candidateTags.Count == 0) { continue; }
                if (!candidateTags.SequenceEqual(tags)) { continue; }

                seriesToUpdate = candidateSeries;
                break;
            }

            if (seriesToUpdate is null)
            {
                seriesToUpdate = new()
                {
                    Metric = metric,
                    Points = [],
                    Tags = tags,
                };
                series.Add(seriesToUpdate);
            }

            seriesToUpdate.Points!.Add(point); // Points is always initialized to an empty list before adding to the series.
        }
    }

    public DistributionRequest? GetRequest()
    {
        lock (lockObject)
        {
            List<DistributionSeries> distToSubmit = series;
            this.series = [];

            if (distToSubmit.Count == 0)
            {
                return null;
            }

            // Add shared tags and resources
            foreach (var series in distToSubmit)
            {
                if (series.Tags is null)
                {
                    series.Tags = sharedTags;
                }
                else
                {
                    series.Tags.AddRange(sharedTags);
                }

                // Note: resources are not yet supported for distributions
                // https://docs.datadoghq.com/api/latest/metrics/#submit-distribution-points
            }

            var model = new Pingmint.Datadog.DistributionRequest()
            {
                Series = distToSubmit
            };
            return model;
        }
    }

    public IDisposable AddScopeDurationSeconds(String metric, List<String> tags)
    {
        return new StopwatchDisposable((s) =>
        {
            var point = new DistributionPoint()
            {
                Value = [s.TotalSeconds],
                Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
            };
            Add(metric, tags, point);
        });
    }
}
