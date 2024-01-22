using Microsoft.Extensions.DependencyInjection;
using MyLib.Abstractions.Clock;
using MyLib.DependencyInjectionExtensions;
using MyLib.Infrastructure.Clock;
using Shouldly;

namespace MyLib.Tests.DependencyInjections;

public class ClockServiceCollectionTests
{
    [Fact]
    public void ClockServiceCollection_ShouldBe_Registered()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddClockService();
        var provider = serviceCollection.BuildServiceProvider();
        var service = provider.GetService<IClock>();
        service.ShouldNotBeNull();
        var option = provider.GetService<ClockOptions>();
        option.ShouldNotBeNull();
    }

    [Fact]
    public void ClockServiceCollection_ShouldBe_Registered_2()
    {
        var serviceCollection = new ServiceCollection();
        var registeredOption = new ClockOptions
        {
            Hours = 2,
            Minutes = 30
        };
        serviceCollection.AddClockService(registeredOption);
        var provider = serviceCollection.BuildServiceProvider();
        var service = provider.GetRequiredService<IClock>();
        service.ShouldNotBeNull();
        var option = provider.GetService<ClockOptions>();
        option.ShouldNotBeNull();
        option.ShouldBeEquivalentTo(registeredOption);
    }

    [Fact]
    public void ClockServiceCollection_ShouldBe_Registered_AsSingleton()
    {
        var serviceCollection = new ServiceCollection();
        var registeredOption = new ClockOptions
        {
            Hours = 2,
            Minutes = 30
        };
        serviceCollection.AddClockService(registeredOption);
        var serviceProvider = serviceCollection.BuildServiceProvider();
        var singletonService1 = serviceProvider.GetService<IClock>();
        var singletonService2 = serviceProvider.GetService<IClock>();
        singletonService1.ShouldBe(singletonService2);
    }
}