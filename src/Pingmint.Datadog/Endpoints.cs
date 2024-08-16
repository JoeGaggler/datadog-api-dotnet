using System.Web;

namespace Pingmint.Datadog;

public static class Endpoints
{
    public const String Incidents = "https://api.datadoghq.com/api/v2/incidents";

    public const String Series = "https://api.datadoghq.com/api/v2/series";

    public static String Incident(String id, String incidents = Incidents) => $"{incidents}/{id}";

    public static String IncidentTodos(String id, String incidents = Incidents) => $"{incidents}/{id}/relationships/todos";

    public static String SearchIncidents(String query = "state:active", String sort = "-created", String incidents = Incidents) =>
        $"{incidents}/search?query={HttpUtility.UrlEncode(query)}&sort={sort}";
}
