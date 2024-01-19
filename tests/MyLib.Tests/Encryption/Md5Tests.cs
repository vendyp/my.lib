using MyLib.Infrastructure.Encryption;
using Shouldly;

namespace MyLib.Tests.Encryption;

public class Md5Tests
{
    [Fact]
    public void Md5_Hash_Tests()
    {
        const string expectedResult = "06db53e28cb810dda69d11c606aa67bc";
        const string parameter = "12344321jffhfee12";
        
        var md5 = new Md5();
        var result = md5.Hash(parameter);
        
        result.ShouldBe(expectedResult);
    }
}