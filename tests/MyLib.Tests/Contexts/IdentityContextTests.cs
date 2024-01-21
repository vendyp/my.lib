using System.Security.Claims;
using MyLib.Infrastructure.Contexts;
using Shouldly;

namespace MyLib.Tests.Contexts;

public class IdentityContextTests
{
    [Fact]
    public void IdentityContext_Ctor_ShouldBe_Ok()
    {
        var identityContext = new IdentityContext();
        identityContext.Claims.ShouldNotBeNull();
        identityContext.Roles.ShouldNotBeNull();
    }

    [Fact]
    public void IdentityContext_Ctor_First_ShouldBe_Ok()
    {
        var id = Guid.NewGuid();
        var identityContext = new IdentityContext(id);
        identityContext.Id.ShouldBe(id);
    }

    [Fact]
    public void IdentityContext_Ctor_Second_ShouldBe_Ok()
    {
        var id = Guid.NewGuid();
        var name = "Test1234";
        var list = new List<Claim>();
        list.Add(new Claim(ClaimTypes.NameIdentifier, id.ToString()));
        list.Add(new Claim(ClaimTypes.Name, name));

        var listRole = new List<Claim>();
        listRole.Add(new Claim(ClaimTypes.Role, "Role1"));
        listRole.Add(new Claim(ClaimTypes.Role, "Role2"));
        listRole.Add(new Claim(ClaimTypes.Role, "Role3"));
        list.AddRange(listRole);

        var claimIdentity = new ClaimsIdentity(list, "test");
        var claimPrincipal = new ClaimsPrincipal(claimIdentity);
        var identityContext = new IdentityContext(claimPrincipal);

        identityContext.IsAuthenticated.ShouldBeTrue();
        identityContext.Claims[ClaimTypes.Role].ToList().ShouldBeEquivalentTo(listRole.Select(e => e.Value).ToList());
        identityContext.Id.ShouldBe(id);
        identityContext.Username.ShouldBe(name);
    }
}