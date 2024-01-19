using System.Security.Cryptography;
using System.Text;
using MyLib.Abstractions.Encryption;

namespace MyLib.Infrastructure.Encryption;

internal sealed class Md5 : IMd5
{
    public string Hash(string value)
    {
        var hash = MD5.HashData(Encoding.UTF8.GetBytes(value));
        var stringBuilder = new StringBuilder();
        foreach (var @byte in hash)
            stringBuilder.Append(@byte.ToString("X2"));

        return stringBuilder.ToString().ToLowerInvariant();
    }
}