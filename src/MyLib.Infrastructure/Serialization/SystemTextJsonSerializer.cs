using System.Text.Json;
using System.Text.Json.Serialization;
using MyLib.Abstractions.Serialization;

namespace MyLib.Infrastructure.Serialization;

internal sealed class SystemTextJsonSerializer : IJsonSerializer
{
    private readonly JsonSerializerOptions _options;

    public SystemTextJsonSerializer(JsonSerializerOptions? options = null)
    {
        _options = options ?? new()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new JsonStringEnumConverter(), new DateOnlyConverter(), new TimeOnlyConverter() }
        };
    }

    public string Serialize<T>(T value) => JsonSerializer.Serialize(value, _options);

    public T? Deserialize<T>(string value) => JsonSerializer.Deserialize<T>(value, _options);

    public object? Deserialize(string value, Type type) => JsonSerializer.Deserialize(value, type, _options);
}