namespace Pingmint.Datadog;

public static class ModelFactory
{
    public static Point CurrentPoint(Decimal value) => new()
    {
        Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
        Value = value
    };

    public static DistributionPoint CurrentDistribution(List<Decimal> values) => new()
    {
        Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
        Value = new(values),
    };
}
