using ProductGallery.Domain.Commom;
using System.Text.Json.Serialization;

namespace ProductGallery.Domain.Entities;

public class Category : EntityBase
{
    public string Name { get; set; }

    [JsonIgnore]
    public virtual ICollection<Product>? Products { get; }

#pragma warning disable CS8618 // Required by Entity Framework
    public Category() { }

    public Category(string name)
    {
        Name = name;
    }
}
