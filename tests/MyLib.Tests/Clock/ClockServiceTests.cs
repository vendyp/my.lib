using MyLib.Infrastructure.Clock;
using Shouldly;

namespace MyLib.Tests.Clock;

public class ClockServiceTests
{
    [Fact]
    public void ClockService_ServerDate()
    {
        var options = new ClockOptions
        {
            Hours = 3
        };
        
        var service = new ClockService(options);
        var dt = service.CurrentServerDate();
        var dt2 = DateTime.UtcNow.AddHours(options.Hours);
        var ts = dt - dt2;
        
        //threshold < 1s
        ts.TotalSeconds.ShouldBeLessThan(1);
    }
}