namespace MyLib.Abstractions.Encryption;

public interface IMd5
{
    string Hash(string value);
}