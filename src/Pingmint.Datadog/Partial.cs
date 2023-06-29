using System.Text;
using System.Text.Json;

namespace Pingmint.Datadog;

public partial class SeriesJsonSerializer
{
    public static String ToJsonString(SeriesRequest model)
    {
        String outJson;
        using (var mem = new MemoryStream())
        {
            var writer = new Utf8JsonWriter(mem, new JsonWriterOptions() { Indented = true });
            try
            {
                Serialize(writer, model);
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
