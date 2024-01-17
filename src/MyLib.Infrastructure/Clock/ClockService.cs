using MyLib.Abstractions.Clock;

namespace MyLib.Infrastructure.Clock;

internal class ClockService : IClock
{
    private readonly ClockOptions _options;

    public ClockService(ClockOptions options)
    {
        _options = options;
    }

    public DateTime CurrentDate()
        => DateTime.UtcNow;

    public DateTime CurrentServerDate()
        => CurrentDate().AddHours(_options.Hours).AddMinutes(_options.Minutes);
}