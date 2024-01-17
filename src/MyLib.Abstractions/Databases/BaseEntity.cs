namespace MyLib.Abstractions.Databases;

public abstract class BaseEntity : IEntity
{
    public string? CreatedBy { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? LastUpdatedBy { get; set; }
    public DateTime? LastUpdatedAt { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; } = false;
}