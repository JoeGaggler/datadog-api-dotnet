using System.IO.Compression;

namespace Pingmint.Datadog;

public static class Http
{
    public static HttpRequestMessage CreateHttpRequest(SeriesRequest model, String key, String endpoint = Endpoints.Series)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint);

        // Headers
        request.Headers.Add("DD-API-KEY", key);
        request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        // Create compressed json content
        var json = SeriesJsonSerializer.ToJsonString(model);
        var jsonBytes = System.Text.Encoding.UTF8.GetBytes(json);
        var gzipBytes = GzipCompress(jsonBytes);
        var content = new ByteArrayContent(gzipBytes);
        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        content.Headers.ContentEncoding.Add("gzip");
        request.Content = content;

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
