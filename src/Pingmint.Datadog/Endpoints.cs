namespace Pingmint.Datadog;

public static class Endpoints
{
    public const String Incidents = "https://api.datadoghq.com/api/v2/incidents";

    public const String Series = "https://api.datadoghq.com/api/v2/series";

    public static String Incident(String id, String incidents = Incidents) => $"{incidents}/{id}";
}
