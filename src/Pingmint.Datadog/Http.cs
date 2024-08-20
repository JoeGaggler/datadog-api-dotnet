using System.IO.Compression;
using System.Net;
using System.Text.Json;

namespace Pingmint.Datadog;

public static class Http
{
    public static HttpRequestMessage CreateSeriesHttpRequest(SeriesRequest model, String key, String endpoint = Endpoints.Series)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint);

        // Headers
        request.Headers.Add("DD-API-KEY", key);
        request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        // Create compressed json content
        request.Content = new SeriesRequestHttpContent(model);

        return request;
    }

    public static HttpRequestMessage CreateDistributionPointsHttpRequest(DistributionRequest model, String key, String endpoint = Endpoints.DistributionPoints)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint);

        // Headers
        request.Headers.Add("DD-API-KEY", key);
        request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        // Create compressed json content
        request.Content = new DistributionPointsRequestHttpContent(model);

        return request;
    }

    public static HttpRequestMessage CreateAppGetHttpRequest(String apiKey, String applicationKey, String endpoint)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, endpoint);

        // Headers
        request.Headers.Add("DD-API-KEY", apiKey);
        request.Headers.Add("DD-APPLICATION-KEY", applicationKey);
        request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        return request;
    }

    public static Byte[] GzipCompress(Byte[] bytes)
    {
        using var memoryStream = new MemoryStream();
        using (var compressStream = new GZipStream(memoryStream, CompressionLevel.Optimal, leaveOpen: true))
        {
            compressStream.Write(bytes);
            compressStream.Flush();
        }

        return memoryStream.ToArray();
    }
}

public class SeriesRequestHttpContent : HttpContent
{
    private readonly SeriesRequest model;

    public SeriesRequestHttpContent(SeriesRequest model)
    {
        this.model = model;
        Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        Headers.ContentEncoding.Add("gzip");
    }

    protected override Task SerializeToStreamAsync(Stream stream, TransportContext? context)
    {
        using (var compressStream = new GZipStream(stream, CompressionLevel.Optimal, leaveOpen: true))
        {
            using (var writer = new Utf8JsonWriter(compressStream, new JsonWriterOptions() { Indented = true, MaxDepth = 8 }))
            {
                JsonSerializer.Serialize(writer, model);
            }
        }

        return Task.CompletedTask;
    }

    protected override bool TryComputeLength(out long length)
    {
        length = 0;
        return false;
    }
}

public class DistributionPointsRequestHttpContent : HttpContent
{
    private readonly DistributionRequest model;

    public DistributionPointsRequestHttpContent(DistributionRequest model)
    {
        this.model = model;
        Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        Headers.ContentEncoding.Add("gzip");
    }

    protected override Task SerializeToStreamAsync(Stream stream, TransportContext? context)
    {
        using (var compressStream = new GZipStream(stream, CompressionLevel.Optimal, leaveOpen: true))
        {
            using (var writer = new Utf8JsonWriter(compressStream, new JsonWriterOptions() { Indented = true, MaxDepth = 8 }))
            {
                DistributionJsonSerializer.Serialize(writer, model);
            }
        }

        return Task.CompletedTask;
    }

    protected override bool TryComputeLength(out long length)
    {
        length = 0;
        return false;
    }
}
