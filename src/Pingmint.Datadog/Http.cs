namespace Pingmint.Datadog;

public static class Http
{
    public static HttpRequestMessage CreateHttpRequest(SeriesRequest model, String key, String endpoint = Endpoints.Series)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint);

        // Headers
        request.Headers.Add("DD-API-KEY", key);
        request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        // Content w/ headers
        request.Content = new StringContent(SeriesJsonSerializer.ToJsonString(model), System.Text.Encoding.UTF8, "application/json");
        request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

        return request;
    }
}
