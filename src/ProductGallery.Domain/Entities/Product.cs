using ProductGallery.Domain.Commom;

namespace ProductGallery.Domain.Entities;

public class Product : EntityBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual Category Category { get; set; }
    public string Image { get; set; }

    public Product(string name) => Name = name;

    public Product(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void AddCategory(string categoryId)
    {
        Category = new Category(categoryId);
    }

    public void AddImage(string image)
    {
        Image = image;
    }
}
