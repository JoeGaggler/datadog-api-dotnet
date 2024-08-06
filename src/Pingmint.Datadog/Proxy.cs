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
}
