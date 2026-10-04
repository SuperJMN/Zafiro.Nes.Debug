using Zafiro.Nes.Debug.Core;

namespace Zafiro.Nes.Debug.Symbols;

public sealed record SymbolInfo(string Name, ushort Address, int? Bank)
{
    public NesAddress ToAddress() => new(Address);
}
