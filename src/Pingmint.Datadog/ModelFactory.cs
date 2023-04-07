namespace Pingmint.Datadog;

public static class ModelFactory
{
    public static Point CurrentPoint(decimal value) =>
        new()
        {
            Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
            Value = value
        };

    public static List<Resource> RequiredResources(String service, String env, String host) =>
        new()
        {
            new()
            {
                Type = "service",
                Name = service
            },
            new()
            {
                Type = "env",
                Name = env
            },
            new()
            {
                Type = "host",
                Name = host
            }
        };

    public static List<Resource> RequiredResources(String service, String env) => RequiredResources(service, env, Environment.MachineName ?? "unknown");
    public static List<Resource> RequiredResources(String service) => RequiredResources(service, Environment.GetEnvironmentVariable("DD_ENV") ?? "unknown");
    public static List<Resource> RequiredResources() => RequiredResources(Environment.GetEnvironmentVariable("DD_SERVICE") ?? "unknown");
}
