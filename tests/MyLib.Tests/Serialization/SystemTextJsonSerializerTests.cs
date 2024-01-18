using MyLib.Infrastructure.Serialization;
using Shouldly;

namespace MyLib.Tests.Serialization;

public class SystemTextJsonSerializerTests
{
    [Fact]
    public void SystemTextJsonSerializer_Test_Serialize()
    {
        string expectedResult = @"{""id"":""1"",""name"":""test""}";

        var service = new SystemTextJsonSerializer();
        var result = service.Serialize(new { id = "1", name = "test" });

        expectedResult.ShouldBe(result);
    }
}