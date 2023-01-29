namespace ProductGallery.Domain.Commom;

public abstract class EntityBase
{
    public virtual Guid Id { get; set; } = Guid.NewGuid();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdateAt { get; set; }
}
