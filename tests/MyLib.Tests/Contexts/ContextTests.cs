using MyLib.Infrastructure.Contexts;
using Shouldly;

namespace MyLib.Tests.Contexts;

public class ContextTests
{
    [Fact]
    public void Context_Ctor_ShouldBe_Ok()
    {
        var context = new Context();
        context.RequestId.ShouldNotBe(Guid.Empty);
    }
}