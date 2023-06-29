#nullable enable
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Pingmint.Datadog;

public static partial class SeriesJsonSerializer
{
	private static JsonTokenType Next(ref Utf8JsonReader reader) => reader.Read() ? reader.TokenType : throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");

	private delegate void DeserializerDelegate<T>(ref Utf8JsonReader r, out T value);
	private static T GetOutParam<T>(ref Utf8JsonReader reader, DeserializerDelegate<T> func) { func(ref reader, out T value); return value; }

	public static void Serialize(Utf8JsonWriter writer, SeriesRequest value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.Series is { } localSeries)
		{
			writer.WritePropertyName("series");
			Serialize0(writer, localSeries);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, out SeriesRequest obj)
	{
		obj = new SeriesRequest();
		while (true)
		{
			switch (Next(ref reader))
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("series"))
					{
						obj.Series = Next(ref reader) switch
						{
							JsonTokenType.Null => null,
							JsonTokenType.StartArray => Deserialize0(ref reader, obj.Series ?? new()),
							var unexpected => throw new InvalidOperationException($"unexpected token type for Series: {unexpected} ")
						};
						break;
					}

					reader.Skip();
					break;
				}
				case JsonTokenType.EndObject:
				{
					return;
				}
				default:
				{
					reader.Skip();
					break;
				}
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, Series value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.Metric is { } localMetric)
		{
			writer.WritePropertyName("metric");
			writer.WriteStringValue(localMetric);
		}
		if (value.Type is { } localType)
		{
			writer.WritePropertyName("type");
			writer.WriteNumberValue(localType);
		}
		if (value.Interval is { } localInterval)
		{
			writer.WritePropertyName("interval");
			writer.WriteNumberValue(localInterval);
		}
		if (value.Unit is { } localUnit)
		{
			writer.WritePropertyName("unit");
			writer.WriteStringValue(localUnit);
		}
		if (value.Points is { } localPoints)
		{
			writer.WritePropertyName("points");
			Serialize1(writer, localPoints);
		}
		if (value.Resources is { } localResources)
		{
			writer.WritePropertyName("resources");
			Serialize2(writer, localResources);
		}
		if (value.Tags is { } localTags)
		{
			writer.WritePropertyName("tags");
			Serialize3(writer, localTags);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, out Series obj)
	{
		obj = new Series();
		while (true)
		{
			switch (Next(ref reader))
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("metric"))
					{
						obj.Metric = Next(ref reader) switch
						{
							JsonTokenType.Null => null,
							JsonTokenType.String => reader.GetString(),
							var unexpected => throw new InvalidOperationException($"unexpected token type for Metric: {unexpected} ")
						};
						break;
					}
					else if (reader.ValueTextEquals("type"))
					{
						obj.Type = Next(ref reader) switch
						{
							JsonTokenType.Null => null,
							JsonTokenType.Number => reader.GetInt32(),
							var unexpected => throw new InvalidOperationException($"unexpected token type for Type: {unexpected} ")
						};
						break;
					}
					else if (reader.ValueTextEquals("interval"))
					{
						obj.Interval = Next(ref reader) switch
						{
							JsonTokenType.Null => null,
							JsonTokenType.Number => reader.GetInt64(),
							var unexpected => throw new InvalidOperationException($"unexpected token type for Interval: {unexpected} ")
						};
						break;
					}
					else if (reader.ValueTextEquals("unit"))
					{
						obj.Unit = Next(ref reader) switch
						{
							JsonTokenType.Null => null,
							JsonTokenType.String => reader.GetString(),
							var unexpected => throw new InvalidOperationException($"unexpected token type for Unit: {unexpected} ")
						};
						break;
					}
					else if (reader.ValueTextEquals("points"))
					{
						obj.Points = Next(ref reader) switch
						{
							JsonTokenType.Null => null,
							JsonTokenType.StartArray => Deserialize1(ref reader, obj.Points ?? new()),
							var unexpected => throw new InvalidOperationException($"unexpected token type for Points: {unexpected} ")
						};
						break;
					}
					else if (reader.ValueTextEquals("resources"))
					{
						obj.Resources = Next(ref reader) switch
						{
							JsonTokenType.Null => null,
							JsonTokenType.StartArray => Deserialize2(ref reader, obj.Resources ?? new()),
							var unexpected => throw new InvalidOperationException($"unexpected token type for Resources: {unexpected} ")
						};
						break;
					}
					else if (reader.ValueTextEquals("tags"))
					{
						obj.Tags = Next(ref reader) switch
						{
							JsonTokenType.Null => null,
							JsonTokenType.StartArray => Deserialize3(ref reader, obj.Tags ?? new()),
							var unexpected => throw new InvalidOperationException($"unexpected token type for Tags: {unexpected} ")
						};
						break;
					}

					reader.Skip();
					break;
				}
				case JsonTokenType.EndObject:
				{
					return;
				}
				default:
				{
					reader.Skip();
					break;
				}
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, Point value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.Timestamp is { } localTimestamp)
		{
			writer.WritePropertyName("timestamp");
			writer.WriteNumberValue(localTimestamp);
		}
		if (value.Value is { } localValue)
		{
			writer.WritePropertyName("value");
			writer.WriteNumberValue(localValue);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, out Point obj)
	{
		obj = new Point();
		while (true)
		{
			switch (Next(ref reader))
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("timestamp"))
					{
						obj.Timestamp = Next(ref reader) switch
						{
							JsonTokenType.Null => null,
							JsonTokenType.Number => reader.GetInt64(),
							var unexpected => throw new InvalidOperationException($"unexpected token type for Timestamp: {unexpected} ")
						};
						break;
					}
					else if (reader.ValueTextEquals("value"))
					{
						obj.Value = Next(ref reader) switch
						{
							JsonTokenType.Null => null,
							JsonTokenType.Number => reader.GetDecimal(),
							var unexpected => throw new InvalidOperationException($"unexpected token type for Value: {unexpected} ")
						};
						break;
					}

					reader.Skip();
					break;
				}
				case JsonTokenType.EndObject:
				{
					return;
				}
				default:
				{
					reader.Skip();
					break;
				}
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, Resource value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.Type is { } localType)
		{
			writer.WritePropertyName("type");
			writer.WriteStringValue(localType);
		}
		if (value.Name is { } localName)
		{
			writer.WritePropertyName("name");
			writer.WriteStringValue(localName);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, out Resource obj)
	{
		obj = new Resource();
		while (true)
		{
			switch (Next(ref reader))
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("type"))
					{
						obj.Type = Next(ref reader) switch
						{
							JsonTokenType.Null => null,
							JsonTokenType.String => reader.GetString(),
							var unexpected => throw new InvalidOperationException($"unexpected token type for Type: {unexpected} ")
						};
						break;
					}
					else if (reader.ValueTextEquals("name"))
					{
						obj.Name = Next(ref reader) switch
						{
							JsonTokenType.Null => null,
							JsonTokenType.String => reader.GetString(),
							var unexpected => throw new InvalidOperationException($"unexpected token type for Name: {unexpected} ")
						};
						break;
					}

					reader.Skip();
					break;
				}
				case JsonTokenType.EndObject:
				{
					return;
				}
				default:
				{
					reader.Skip();
					break;
				}
			}
		}
	}
	private static void Serialize0<TArray>(Utf8JsonWriter writer, TArray array) where TArray : ICollection<Series>
	{
		if (array is null) { writer.WriteNullValue(); return; }
		writer.WriteStartArray();
		foreach (var item in array)
		{
			Serialize(writer, item);
		}
		writer.WriteEndArray();
	}

	private static TArray Deserialize0<TArray>(ref Utf8JsonReader reader, TArray array) where TArray : ICollection<Series>
	{
		while (true)
		{
			switch (Next(ref reader))
			{
				case JsonTokenType.Null:
				{
					reader.Skip();
					break;
				}
				case JsonTokenType.StartObject:
				{
					Deserialize(ref reader, out Series value);
					var item = value;
					array.Add(item);
					break;
				}
				case JsonTokenType.EndArray:
				{
					return array;
				}
				default:
				{
					reader.Skip();
					break;
				}
			}
		}
	}
	private static void Serialize1<TArray>(Utf8JsonWriter writer, TArray array) where TArray : ICollection<Point>
	{
		if (array is null) { writer.WriteNullValue(); return; }
		writer.WriteStartArray();
		foreach (var item in array)
		{
			Serialize(writer, item);
		}
		writer.WriteEndArray();
	}

	private static TArray Deserialize1<TArray>(ref Utf8JsonReader reader, TArray array) where TArray : ICollection<Point>
	{
		while (true)
		{
			switch (Next(ref reader))
			{
				case JsonTokenType.Null:
				{
					reader.Skip();
					break;
				}
				case JsonTokenType.StartObject:
				{
					Deserialize(ref reader, out Point value);
					var item = value;
					array.Add(item);
					break;
				}
				case JsonTokenType.EndArray:
				{
					return array;
				}
				default:
				{
					reader.Skip();
					break;
				}
			}
		}
	}
	private static void Serialize2<TArray>(Utf8JsonWriter writer, TArray array) where TArray : ICollection<Resource>
	{
		if (array is null) { writer.WriteNullValue(); return; }
		writer.WriteStartArray();
		foreach (var item in array)
		{
			Serialize(writer, item);
		}
		writer.WriteEndArray();
	}

	private static TArray Deserialize2<TArray>(ref Utf8JsonReader reader, TArray array) where TArray : ICollection<Resource>
	{
		while (true)
		{
			switch (Next(ref reader))
			{
				case JsonTokenType.Null:
				{
					reader.Skip();
					break;
				}
				case JsonTokenType.StartObject:
				{
					Deserialize(ref reader, out Resource value);
					var item = value;
					array.Add(item);
					break;
				}
				case JsonTokenType.EndArray:
				{
					return array;
				}
				default:
				{
					reader.Skip();
					break;
				}
			}
		}
	}
	private static void Serialize3<TArray>(Utf8JsonWriter writer, TArray array) where TArray : ICollection<String>
	{
		if (array is null) { writer.WriteNullValue(); return; }
		writer.WriteStartArray();
		foreach (var item in array)
		{
			writer.WriteStringValue(item);
		}
		writer.WriteEndArray();
	}

	private static TArray Deserialize3<TArray>(ref Utf8JsonReader reader, TArray array) where TArray : ICollection<String>
	{
		while (true)
		{
			switch (Next(ref reader))
			{
				case JsonTokenType.Null:
				{
					reader.Skip();
					break;
				}
				case JsonTokenType.String:
				{
					var item = reader.GetString();
					array.Add(item);
					break;
				}
				case JsonTokenType.EndArray:
				{
					return array;
				}
				default:
				{
					reader.Skip();
					break;
				}
			}
		}
	}
}
public sealed partial class SeriesRequest
{
	public List<Series>? Series { get; set; }
}
public sealed partial class Series
{
	public String? Metric { get; set; }
	public Int32? Type { get; set; }
	public Int64? Interval { get; set; }
	public String? Unit { get; set; }
	public List<Point>? Points { get; set; }
	public List<Resource>? Resources { get; set; }
	public List<String>? Tags { get; set; }
}
public sealed partial class Point
{
	public Int64? Timestamp { get; set; }
	public Decimal? Value { get; set; }
}
public sealed partial class Resource
{
	public String? Type { get; set; }
	public String? Name { get; set; }
}
