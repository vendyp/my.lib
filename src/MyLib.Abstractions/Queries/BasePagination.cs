namespace MyLib.Abstractions.Queries;

public abstract class BasePagination
{
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;
    public string? OrderBy { get; set; }
    public string? OrderType { get; set; }
    public int CalculateSkip() => (Page - 1) * Size;
}