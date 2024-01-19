using MyLib.Infrastructure.Encryption;
using Shouldly;

namespace MyLib.Tests.Encryption;

public class Sha256Tests
{
    [Fact]
    public void Sha256_Hash_Tests()
    {
        const string parameter = "qwerty@12345@1234";
        const string expectedResult = "e7697ce22baf29a097b33e4fcd041946787d9be2b3d252d30f3611286320e951";

        var sha256 = new Sha256();
        var result = sha256.Hash(parameter);

        result.ShouldBe(expectedResult);
    }
}