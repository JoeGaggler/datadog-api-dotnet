#nullable enable
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Pingmint.Datadog;

public partial class JsonSerializer :
    JsonSerializer.ISerializes<SeriesRequest>,
    JsonSerializer.ISerializes<Series>,
    JsonSerializer.ISerializes<Point>,
    JsonSerializer.ISerializes<Resource>,
    JsonSerializer.ISerializes<IncidentsResponse>,
    JsonSerializer.ISerializes<IncidentsResponseData>,
    JsonSerializer.ISerializes<IncidentResponse>,
    JsonSerializer.ISerializes<IncidentResponseData>,
    JsonSerializer.ISerializes<IncidentResponseDataAttributes>,
    JsonSerializer.ISerializes<IncidentResponseDataAttributesFields>,
    JsonSerializer.ISerializes<IncidentsSearchResponse>,
    JsonSerializer.ISerializes<IncidentsSearchResponseIncluded>,
    JsonSerializer.ISerializes<TextBoxValue>
{
	public interface ISerializes<T> where T : notnull
	{
		static abstract void Serialize(Utf8JsonWriter writer, T? value);
		static abstract void Deserialize(ref Utf8JsonReader reader, T value);
	}

	public static void Serialize(Utf8JsonWriter writer, SeriesRequest? value)
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

	public static void Deserialize(ref Utf8JsonReader reader, SeriesRequest obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("series"))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Series = null; break; }
						if (reader.TokenType == JsonTokenType.StartArray) { obj.Series = Deserialize0(ref reader, obj.Series ?? new()); break; }
						throw new InvalidOperationException($"unexpected token type for Series: {reader.TokenType} ");
					}

					reader.Skip();
					reader.Skip();
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, Series? value)
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

	public static void Deserialize(ref Utf8JsonReader reader, Series obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("metric"))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Metric = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Metric = reader.GetString(); break; }
						throw new InvalidOperationException($"unexpected token type for Metric: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("type"))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Type = null; break; }
						if (reader.TokenType == JsonTokenType.Number) { obj.Type = reader.GetInt32(); break; }
						throw new InvalidOperationException($"unexpected token type for Type: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("interval"))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Interval = null; break; }
						if (reader.TokenType == JsonTokenType.Number) { obj.Interval = reader.GetInt64(); break; }
						throw new InvalidOperationException($"unexpected token type for Interval: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("unit"))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Unit = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Unit = reader.GetString(); break; }
						throw new InvalidOperationException($"unexpected token type for Unit: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("points"))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Points = null; break; }
						if (reader.TokenType == JsonTokenType.StartArray) { obj.Points = Deserialize1(ref reader, obj.Points ?? new()); break; }
						throw new InvalidOperationException($"unexpected token type for Points: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("resources"))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Resources = null; break; }
						if (reader.TokenType == JsonTokenType.StartArray) { obj.Resources = Deserialize2(ref reader, obj.Resources ?? new()); break; }
						throw new InvalidOperationException($"unexpected token type for Resources: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("tags"))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Tags = null; break; }
						if (reader.TokenType == JsonTokenType.StartArray) { obj.Tags = Deserialize3(ref reader, obj.Tags ?? new()); break; }
						throw new InvalidOperationException($"unexpected token type for Tags: {reader.TokenType} ");
					}

					reader.Skip();
					reader.Skip();
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, Point? value)
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

	public static void Deserialize(ref Utf8JsonReader reader, Point obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("timestamp"))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Timestamp = null; break; }
						if (reader.TokenType == JsonTokenType.Number) { obj.Timestamp = reader.GetInt64(); break; }
						throw new InvalidOperationException($"unexpected token type for Timestamp: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("value"))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Value = null; break; }
						if (reader.TokenType == JsonTokenType.Number) { obj.Value = reader.GetDecimal(); break; }
						throw new InvalidOperationException($"unexpected token type for Value: {reader.TokenType} ");
					}

					reader.Skip();
					reader.Skip();
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, Resource? value)
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

	public static void Deserialize(ref Utf8JsonReader reader, Resource obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("type"))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Type = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Type = reader.GetString(); break; }
						throw new InvalidOperationException($"unexpected token type for Type: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("name"))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Name = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Name = reader.GetString(); break; }
						throw new InvalidOperationException($"unexpected token type for Name: {reader.TokenType} ");
					}

					reader.Skip();
					reader.Skip();
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, IncidentsResponse? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.Data is { } localData)
		{
			writer.WritePropertyName("data");
			Serialize4(writer, localData);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, IncidentsResponse obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("data"))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Data = null; break; }
						if (reader.TokenType == JsonTokenType.StartArray) { obj.Data = Deserialize4(ref reader, obj.Data ?? new()); break; }
						throw new InvalidOperationException($"unexpected token type for Data: {reader.TokenType} ");
					}

					reader.Skip();
					reader.Skip();
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, IncidentsResponseData? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.Id is { } localId)
		{
			writer.WritePropertyName("id");
			writer.WriteStringValue(localId);
		}
		if (value.Attributes is { } localAttributes)
		{
			writer.WritePropertyName("attributes");
			Serialize(writer, localAttributes);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, IncidentsResponseData obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("id"))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Id = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Id = reader.GetString(); break; }
						throw new InvalidOperationException($"unexpected token type for Id: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("attributes"))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Attributes = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.Attributes = new(); Deserialize(ref reader, obj.Attributes); break; }
						throw new InvalidOperationException($"unexpected token type for Attributes: {reader.TokenType} ");
					}

					reader.Skip();
					reader.Skip();
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, IncidentResponse? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.Id is { } localId)
		{
			writer.WritePropertyName("id");
			writer.WriteStringValue(localId);
		}
		if (value.Data is { } localData)
		{
			writer.WritePropertyName("data");
			Serialize(writer, localData);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, IncidentResponse obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("id"))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Id = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Id = reader.GetString(); break; }
						throw new InvalidOperationException($"unexpected token type for Id: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("data"))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Data = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.Data = new(); Deserialize(ref reader, obj.Data); break; }
						throw new InvalidOperationException($"unexpected token type for Data: {reader.TokenType} ");
					}

					reader.Skip();
					reader.Skip();
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, IncidentResponseData? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.Attributes is { } localAttributes)
		{
			writer.WritePropertyName("attributes");
			Serialize(writer, localAttributes);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, IncidentResponseData obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("attributes"))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Attributes = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.Attributes = new(); Deserialize(ref reader, obj.Attributes); break; }
						throw new InvalidOperationException($"unexpected token type for Attributes: {reader.TokenType} ");
					}

					reader.Skip();
					reader.Skip();
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, IncidentResponseDataAttributes? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.Created is { } localCreated)
		{
			writer.WritePropertyName("created");
			writer.WriteStringValue(localCreated);
		}
		if (value.Detected is { } localDetected)
		{
			writer.WritePropertyName("detected");
			writer.WriteStringValue(localDetected);
		}
		if (value.Fields is { } localFields)
		{
			writer.WritePropertyName("fields");
			Serialize(writer, localFields);
		}
		if (value.Modified is { } localModified)
		{
			writer.WritePropertyName("modified");
			writer.WriteStringValue(localModified);
		}
		if (value.PublicId is { } localPublicId)
		{
			writer.WritePropertyName("public_id");
			writer.WriteNumberValue(localPublicId);
		}
		if (value.Resolved is { } localResolved)
		{
			writer.WritePropertyName("resolved");
			writer.WriteStringValue(localResolved);
		}
		if (value.Severity is { } localSeverity)
		{
			writer.WritePropertyName("severity");
			writer.WriteStringValue(localSeverity);
		}
		if (value.State is { } localState)
		{
			writer.WritePropertyName("state");
			writer.WriteStringValue(localState);
		}
		if (value.Title is { } localTitle)
		{
			writer.WritePropertyName("title");
			writer.WriteStringValue(localTitle);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, IncidentResponseDataAttributes obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("created"))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Created = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Created = reader.GetString(); break; }
						throw new InvalidOperationException($"unexpected token type for Created: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("detected"))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Detected = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Detected = reader.GetString(); break; }
						throw new InvalidOperationException($"unexpected token type for Detected: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("fields"))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Fields = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.Fields = new(); Deserialize(ref reader, obj.Fields); break; }
						throw new InvalidOperationException($"unexpected token type for Fields: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("modified"))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Modified = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Modified = reader.GetString(); break; }
						throw new InvalidOperationException($"unexpected token type for Modified: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("public_id"))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.PublicId = null; break; }
						if (reader.TokenType == JsonTokenType.Number) { obj.PublicId = reader.GetInt32(); break; }
						throw new InvalidOperationException($"unexpected token type for PublicId: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("resolved"))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Resolved = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Resolved = reader.GetString(); break; }
						throw new InvalidOperationException($"unexpected token type for Resolved: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("severity"))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Severity = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Severity = reader.GetString(); break; }
						throw new InvalidOperationException($"unexpected token type for Severity: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("state"))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.State = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.State = reader.GetString(); break; }
						throw new InvalidOperationException($"unexpected token type for State: {reader.TokenType} ");
					}
					else if (reader.ValueTextEquals("title"))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Title = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Title = reader.GetString(); break; }
						throw new InvalidOperationException($"unexpected token type for Title: {reader.TokenType} ");
					}

					reader.Skip();
					reader.Skip();
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, IncidentResponseDataAttributesFields? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.Summary is { } localSummary)
		{
			writer.WritePropertyName("summary");
			Serialize(writer, localSummary);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, IncidentResponseDataAttributesFields obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("summary"))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Summary = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.Summary = new(); Deserialize(ref reader, obj.Summary); break; }
						throw new InvalidOperationException($"unexpected token type for Summary: {reader.TokenType} ");
					}

					reader.Skip();
					reader.Skip();
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, IncidentsSearchResponse? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.Included is { } localIncluded)
		{
			writer.WritePropertyName("included");
			Serialize5(writer, localIncluded);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, IncidentsSearchResponse obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("included"))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Included = null; break; }
						if (reader.TokenType == JsonTokenType.StartArray) { obj.Included = Deserialize5(ref reader, obj.Included ?? new()); break; }
						throw new InvalidOperationException($"unexpected token type for Included: {reader.TokenType} ");
					}

					reader.Skip();
					reader.Skip();
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, IncidentsSearchResponseIncluded? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.Attributes is { } localAttributes)
		{
			writer.WritePropertyName("attributes");
			Serialize(writer, localAttributes);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, IncidentsSearchResponseIncluded obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("attributes"))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Attributes = null; break; }
						if (reader.TokenType == JsonTokenType.StartObject) { obj.Attributes = new(); Deserialize(ref reader, obj.Attributes); break; }
						throw new InvalidOperationException($"unexpected token type for Attributes: {reader.TokenType} ");
					}

					reader.Skip();
					reader.Skip();
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
			}
		}
	}
	public static void Serialize(Utf8JsonWriter writer, TextBoxValue? value)
	{
		if (value is null) { writer.WriteNullValue(); return; }
		writer.WriteStartObject();
		if (value.Value is { } localValue)
		{
			writer.WritePropertyName("value");
			writer.WriteStringValue(localValue);
		}
		writer.WriteEndObject();
	}

	public static void Deserialize(ref Utf8JsonReader reader, TextBoxValue obj)
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.PropertyName:
				{
					if (reader.ValueTextEquals("value"))
					{
						if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
						if (reader.TokenType == JsonTokenType.Null) { obj.Value = null; break; }
						if (reader.TokenType == JsonTokenType.String) { obj.Value = reader.GetString(); break; }
						throw new InvalidOperationException($"unexpected token type for Value: {reader.TokenType} ");
					}

					reader.Skip();
					reader.Skip();
					break;
				}
				case JsonTokenType.EndObject: { return; }
				default: { reader.Skip(); break; }
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
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.Null: { reader.Skip(); break; }
				case JsonTokenType.StartObject:
				{
					Series item = new();
					Deserialize(ref reader, item);
					array.Add(item);
					break;
				}
				case JsonTokenType.EndArray: { return array; }
				default: { reader.Skip(); break; }
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
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.Null: { reader.Skip(); break; }
				case JsonTokenType.StartObject:
				{
					Point item = new();
					Deserialize(ref reader, item);
					array.Add(item);
					break;
				}
				case JsonTokenType.EndArray: { return array; }
				default: { reader.Skip(); break; }
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
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.Null: { reader.Skip(); break; }
				case JsonTokenType.StartObject:
				{
					Resource item = new();
					Deserialize(ref reader, item);
					array.Add(item);
					break;
				}
				case JsonTokenType.EndArray: { return array; }
				default: { reader.Skip(); break; }
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
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.Null: { reader.Skip(); break; }
				case JsonTokenType.String:
				{
					var item = reader.GetString();
					array.Add(item);
					break;
				}
				case JsonTokenType.EndArray: { return array; }
				default: { reader.Skip(); break; }
			}
		}
	}
	private static void Serialize4<TArray>(Utf8JsonWriter writer, TArray array) where TArray : ICollection<IncidentsResponseData>
	{
		if (array is null) { writer.WriteNullValue(); return; }
		writer.WriteStartArray();
		foreach (var item in array)
		{
			Serialize(writer, item);
		}
		writer.WriteEndArray();
	}

	private static TArray Deserialize4<TArray>(ref Utf8JsonReader reader, TArray array) where TArray : ICollection<IncidentsResponseData>
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.Null: { reader.Skip(); break; }
				case JsonTokenType.StartObject:
				{
					IncidentsResponseData item = new();
					Deserialize(ref reader, item);
					array.Add(item);
					break;
				}
				case JsonTokenType.EndArray: { return array; }
				default: { reader.Skip(); break; }
			}
		}
	}
	private static void Serialize5<TArray>(Utf8JsonWriter writer, TArray array) where TArray : ICollection<IncidentsSearchResponseIncluded>
	{
		if (array is null) { writer.WriteNullValue(); return; }
		writer.WriteStartArray();
		foreach (var item in array)
		{
			Serialize(writer, item);
		}
		writer.WriteEndArray();
	}

	private static TArray Deserialize5<TArray>(ref Utf8JsonReader reader, TArray array) where TArray : ICollection<IncidentsSearchResponseIncluded>
	{
		while (true)
		{
			if (!reader.Read()) throw new InvalidOperationException("Unable to read next token from Utf8JsonReader");
			switch (reader.TokenType)
			{
				case JsonTokenType.Null: { reader.Skip(); break; }
				case JsonTokenType.StartObject:
				{
					IncidentsSearchResponseIncluded item = new();
					Deserialize(ref reader, item);
					array.Add(item);
					break;
				}
				case JsonTokenType.EndArray: { return array; }
				default: { reader.Skip(); break; }
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
public sealed partial class IncidentsResponse
{
	public List<IncidentsResponseData>? Data { get; set; }
}
public sealed partial class IncidentsResponseData
{
	public String? Id { get; set; }
	public IncidentResponseDataAttributes? Attributes { get; set; }
}
public sealed partial class IncidentResponse
{
	public String? Id { get; set; }
	public IncidentResponseData? Data { get; set; }
}
public sealed partial class IncidentResponseData
{
	public IncidentResponseDataAttributes? Attributes { get; set; }
}
public sealed partial class IncidentResponseDataAttributes
{
	public String? Created { get; set; }
	public String? Detected { get; set; }
	public IncidentResponseDataAttributesFields? Fields { get; set; }
	public String? Modified { get; set; }
	public Int32? PublicId { get; set; }
	public String? Resolved { get; set; }
	public String? Severity { get; set; }
	public String? State { get; set; }
	public String? Title { get; set; }
}
public sealed partial class IncidentResponseDataAttributesFields
{
	public TextBoxValue? Summary { get; set; }
}
public sealed partial class IncidentsSearchResponse
{
	public List<IncidentsSearchResponseIncluded>? Included { get; set; }
}
public sealed partial class IncidentsSearchResponseIncluded
{
	public IncidentResponseDataAttributes? Attributes { get; set; }
}
public sealed partial class TextBoxValue
{
	public String? Value { get; set; }
}
