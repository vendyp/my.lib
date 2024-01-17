using Shouldly;

namespace MyLib.Tests;

public class RunTests
{
    [Fact]
    public void Run()
    {
        true.ShouldBeTrue();
    }
}