using MyLib.Infrastructure.Encryption;
using Shouldly;

namespace MyLib.Tests.Encryption;

public class Sha512Tests
{
    [Fact]
    public void Sha512_Hash_Tests()
    {
        const string parameter = "qwerty@1234$#21";
        const string expectedResult = "69d8b7a7b15fd40d533359025599c8c45a96197f729ceee3e79b179232dc288eef04e85ae0c21833120f4445147b8ffd560ddc4c58d0a5593c81be9edd89a47b";

        var sha512 = new Sha512();
        var result = sha512.Hash(parameter);
        
        result.ShouldBe(expectedResult);
    }
}