namespace Pingmint.Datadog;

public static class ModelFactory
{
    public static Point CurrentPoint(decimal value) => new()
    {
        Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
        Value = value
    };
}
