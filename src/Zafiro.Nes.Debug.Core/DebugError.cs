using System.Text.Json.Serialization;

namespace Zafiro.Nes.Debug.Core;

public sealed record DebugError(
    [property: JsonPropertyName("code")] string Code,
    [property: JsonPropertyName("message")] string Message);
