namespace Pingmint.Datadog;

public static class Proxy
{
    public static async Task<IncidentResponse?> GetIncidentAsync(String incidentId, String apiKey, String applicationKey, HttpClient http, CancellationToken cancellationToken)
    {
        var request = Pingmint.Datadog.Http.CreateAppGetHttpRequest(apiKey, applicationKey, Endpoints.Incident(incidentId));
        var response = await http.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsByteArrayAsync(cancellationToken);
        return Json.Deserialize<IncidentResponse>(json, JsonSerializer.Deserialize);
    }

    public static async Task<IncidentTodosResponse?> GetIncidentTodosAsync(String incidentId, String apiKey, String applicationKey, HttpClient http, CancellationToken cancellationToken)
    {
        var request = Pingmint.Datadog.Http.CreateAppGetHttpRequest(apiKey, applicationKey, Endpoints.IncidentTodos(incidentId));
        var response = await http.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsByteArrayAsync(cancellationToken);
        return Json.Deserialize<IncidentTodosResponse>(json, JsonSerializer.Deserialize);
    }

    public static async Task<IncidentsSearchResponse?> SearchIncidentsAsync(String query, String sort, String apiKey, String applicationKey, HttpClient http, CancellationToken cancellationToken)
    {
        var request = Pingmint.Datadog.Http.CreateAppGetHttpRequest(apiKey, applicationKey, Endpoints.SearchIncidents(query: query, sort: sort));
        var response = await http.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsByteArrayAsync(cancellationToken);
        return Json.Deserialize<IncidentsSearchResponse>(json, JsonSerializer.Deserialize);
    }
}
