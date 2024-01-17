namespace MyLib.Abstractions.Encryption;

public interface IRng
{
    string Generate(int length = 64);
}