using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MyLib.Abstractions.Clock;
using MyLib.Infrastructure.Clock;

namespace MyLib.DependencyInjectionExtensions;

public static class ClockServiceCollection
{
    public static void AddClockService(this IServiceCollection services)
    {
        services.TryAddSingleton(new ClockOptions());
        services.TryAddSingleton<IClock, ClockService>();
    }

    public static void AddClockService(this IServiceCollection services, ClockOptions clockOptions)
    {
        services.TryAddSingleton(clockOptions);
        services.TryAddSingleton<IClock, ClockService>();
    }
}