using ProductGallery.Domain.Entities;
using System.Collections;

namespace ProductGallery.Persistence.Data.Seeders;

internal class CategorySeeder : IEnumerable<Category>
{
    readonly List<Category> categorylist = new()
    {
        new Category("Computación"),
        new Category("Ropa"),
        new Category("Accesorios"),
        new Category("Libros"),
        new Category("Cocina"),
        new Category("Juegos"),
        new Category("Tecnología")
    };

    public IEnumerator<Category> GetEnumerator()
    {
        return categorylist.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
