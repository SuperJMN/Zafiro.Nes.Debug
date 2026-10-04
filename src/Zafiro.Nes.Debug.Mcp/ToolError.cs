using System.Text.Json.Serialization;
using Zafiro.Nes.Debug.Core;

namespace Zafiro.Nes.Debug.Mcp;

public sealed record ToolError(
    [property: JsonPropertyName("error")] DebugError Error,
    [property: JsonPropertyName("diagnostics")]
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    ExecutionFailureDiagnostics? Diagnostics = null);

public sealed record ExecutionFailureDiagnostics(
    [property: JsonPropertyName("backend")] string Backend,
    [property: JsonPropertyName("backendVersion")] string BackendVersion,
    [property: JsonPropertyName("serverVersion")] string ServerVersion,
    [property: JsonPropertyName("debugCycleLimit")]
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    int? DebugCycleLimit);
