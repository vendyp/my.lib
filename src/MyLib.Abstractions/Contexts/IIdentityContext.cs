namespace MyLib.Abstractions.Contexts;

public interface IIdentityContext
{
    bool IsAuthenticated { get; }
    public Guid Id { get; }
    public string Username { get; }
    List<string> Roles { get; }
    Dictionary<string, IEnumerable<string>> Claims { get; }
}