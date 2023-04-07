using System.Text;
using System.Text.Json;

namespace Pingmint.Datadog;

public partial class SeriesJsonSerializer
{
    public static String ToJsonString(SeriesRequest self) => ToJsonString(SeriesRequest, self);

    private static String ToJsonString<TModel>(IJsonSerializer<TModel> serializer, TModel model)
    {
        String outJson;
        using (var mem = new MemoryStream())
        {
            var writer = new Utf8JsonWriter(mem, new JsonWriterOptions() { Indented = true });
            try
            {
                serializer.Serialize(ref writer, model);
            }
            finally
            {
                writer.Dispose();
            }
            outJson = Encoding.UTF8.GetString(mem.ToArray());
        }

        return outJson;
    }
}
