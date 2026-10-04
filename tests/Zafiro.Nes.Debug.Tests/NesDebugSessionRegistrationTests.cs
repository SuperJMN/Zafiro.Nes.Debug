using Microsoft.Extensions.DependencyInjection;
using Zafiro.Nes.Debug.Core;
using Zafiro.Nes.Debug.Emulator;
using Zafiro.Nes.Debug.Mcp;

namespace Zafiro.Nes.Debug.Tests;

public sealed class NesDebugSessionRegistrationTests
{
    [Fact]
    public async Task Registration_resolves_the_direct_synchronized_aprnes_session_without_deadlocking()
    {
        var services = new ServiceCollection();
        services.AddNesDebugSession();
        using var provider = services.BuildServiceProvider();

        var resolve = Task.Run(() => provider.GetRequiredService<INesDebugSession>());
        var completed = await Task.WhenAny(resolve, Task.Delay(TimeSpan.FromSeconds(10)));

        Assert.True(completed == resolve, "Resolving INesDebugSession deadlocked.");
        var session = await resolve;
        var state = session.GetState();

        Assert.IsType<SynchronizedNesDebugSession>(session);
        Assert.True(state.IsSuccess, state.Error?.Message);
        Assert.Equal("AprNes", state.Value.Backend);
        Assert.Contains(services, descriptor => descriptor.ServiceType == typeof(AprNesDebugSession));
    }
}
