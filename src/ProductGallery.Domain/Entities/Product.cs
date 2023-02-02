using ProductGallery.Domain.Commom;

namespace ProductGallery.Domain.Entities;

public class Product : EntityBase
{
    public Guid CategoryId { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public string? ImageUrl { get; set; }

    public virtual Category? Category { get; set; }

    public Product(string name, string description = "")
    {
        Name = name;
        Description = description;
    }

    public void AddCategory(Category category)
    {
        CategoryId = category.Id;
    }


    public void AddImage(string imageUrl)
    {
        ImageUrl = imageUrl;
    }
}
