using System.Security.Claims;
using MyLib.Abstractions.Contexts;

namespace MyLib.Infrastructure.Contexts;

internal sealed class IdentityContext : IIdentityContext
{
    public bool IsAuthenticated { get; }
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public Dictionary<string, IEnumerable<string>> Claims { get; }
    public List<string> Roles { get; }

    public IdentityContext()
    {
        Roles = new List<string>();
        Claims = new Dictionary<string, IEnumerable<string>>();
    }

    public IdentityContext(Guid id) : this()
    {
        Id = id;
    }

    public IdentityContext(ClaimsPrincipal principal) : this()
    {
        if (principal.Identity is null || string.IsNullOrWhiteSpace(principal.Identity.Name))
            return;

        IsAuthenticated = principal.Identity?.IsAuthenticated is true;

        if (principal.Claims.Any(e => e.Type == ClaimTypes.Role))
            foreach (var claim in principal.Claims.Where(e => e.Type == ClaimTypes.Role))
                Roles.Add(claim.Value);

        Id = new Guid(principal.Claims.SingleOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value!);
        Username = principal.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Name)?.Value!;
        Claims = principal.Claims.GroupBy(x => x.Type)
            .ToDictionary(x => x.Key, x => x.Select(c => c.Value.ToString()));
    }

    public static IIdentityContext Empty => new IdentityContext();
}