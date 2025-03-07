#nullable enable
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Pingmint.Datadog;

public partial class DistributionJsonSerializer
{
    public static void Serialize(Utf8JsonWriter writer, DistributionRequest? value)
    {
        if (value is null) { writer.WriteNullValue(); return; }
        writer.WriteStartObject();
        if (value.Series is { } localSeries)
        {
            writer.WritePropertyName("series");
            Serialize4(writer, localSeries);
        }
        writer.WriteEndObject();
    }

    public static void Deserialize(ref Utf8JsonReader reader, DistributionRequest obj)
    {
        throw new NotImplementedException();
    }

    public static void Serialize(Utf8JsonWriter writer, DistributionSeries? value)
    {
        if (value is null) { writer.WriteNullValue(); return; }
        writer.WriteStartObject();
        if (value.Metric is { } localMetric)
        {
            writer.WritePropertyName("metric");
            writer.WriteStringValue(localMetric);
        }
        if (value.Points is { } localPoints)
        {
            writer.WritePropertyName("points");
            Serialize5(writer, localPoints);
        }
        if (value.Tags is { } localTags)
        {
            writer.WritePropertyName("tags");
            Serialize6(writer, localTags);
        }
        writer.WriteEndObject();
    }

    public static void Deserialize(ref Utf8JsonReader reader, DistributionSeries obj)
    {
        throw new NotImplementedException();
    }

    public static void Serialize(Utf8JsonWriter writer, DistributionPoint? value)
    {
        writer.WriteStartArray();
        if (value is null) { writer.WriteNullValue(); return; }
        if (value.Timestamp is { } localTimestamp)
        {
            writer.WriteNumberValue(localTimestamp);
        }
        else
        {
            writer.WriteNumberValue(DateTimeOffset.Now.ToUnixTimeSeconds());
        }

        writer.WriteStartArray();
        if (value.Value is { } localValue)
        {
            foreach (var item in localValue)
            {
                writer.WriteNumberValue(item);
            }
        }
        writer.WriteEndArray();
        writer.WriteEndArray();
    }

    public static void Deserialize(ref Utf8JsonReader reader, DistributionPoint obj)
    {
        throw new NotImplementedException();
    }

    private static void Serialize5<TArray>(Utf8JsonWriter writer, TArray array) where TArray : ICollection<DistributionPoint>
    {
        if (array is null) { writer.WriteNullValue(); return; }
        writer.WriteStartArray();
        foreach (var item in array)
        {
            Serialize(writer, item);
        }
        writer.WriteEndArray();
    }

    private static void Serialize4<TArray>(Utf8JsonWriter writer, TArray array) where TArray : ICollection<DistributionSeries>
    {
        if (array is null) { writer.WriteNullValue(); return; }
        writer.WriteStartArray();
        foreach (var item in array)
        {
            Serialize(writer, item);
        }
        writer.WriteEndArray();
    }

    private static void Serialize6<TArray>(Utf8JsonWriter writer, TArray array) where TArray : ICollection<String>
    {
        if (array is null) { writer.WriteNullValue(); return; }
        writer.WriteStartArray();
        foreach (var item in array)
        {
            writer.WriteStringValue(item);
        }
        writer.WriteEndArray();
    }
}

public sealed partial class DistributionRequest
{
    public List<DistributionSeries>? Series { get; set; }
}
public sealed partial class DistributionSeries
{
    public String? Metric { get; set; }
    public List<DistributionPoint>? Points { get; set; }
    public List<String>? Tags { get; set; }
}
public sealed partial class DistributionPoint
{
    public Int64? Timestamp { get; set; }
    public List<Decimal>? Value { get; set; }
}
