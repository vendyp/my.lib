namespace MyLib.Abstractions.Clock;

public interface IClock
{
    DateTime CurrentDate();
    DateTime CurrentServerDate();
}