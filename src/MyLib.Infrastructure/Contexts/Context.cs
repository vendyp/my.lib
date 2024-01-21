using MyLib.Abstractions.Contexts;

namespace MyLib.Infrastructure.Contexts;

internal sealed class Context : IContext
{
    public Guid RequestId { get; } = Guid.NewGuid();
    public string? TraceId { get; set; }
    public string? IpAddress { get; set; }
    public string? UserAgent { get; set; }
    public IIdentityContext Identity { get; } = IdentityContext.Empty;
}