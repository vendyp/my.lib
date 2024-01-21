namespace MyLib.Abstractions.Contexts;

public interface IContext
{
    Guid RequestId { get; }
    string? IpAddress { get; }
    string? TraceId { get; }
    string? UserAgent { get; }
    IIdentityContext Identity { get; }
}