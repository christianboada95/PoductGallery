using ProductGallery.Domain.Entities;
using System.Collections;

namespace ProductGallery.Persistence.Data.Seeders;

internal class CategorySeeder : IEnumerable<Category>
{
    readonly List<Category> categorylist = new()
    {
        new Category("Computación") { Id = Guid.Parse("a422b632-e3da-480f-b237-c551b14f84c0") },
        new Category("Ropa") { Id = Guid.Parse("b652bc42-9e7c-47dd-8331-73cfc3fee183") },
        new Category("Accesorios") { Id = Guid.Parse("1d643885-fe4b-4a90-8fae-a8218b80b915") },
        new Category("Libros") { Id = Guid.Parse("a1ff8e63-2c4d-46b4-a684-595d389be365") },
        new Category("Cocina") { Id = Guid.Parse("a4745a21-cd2a-4b95-bc0b-a7ec9b12434f") },
        new Category("Juegos") { Id = Guid.Parse("47ae148e-3623-46ba-a13e-995937216853") },
        new Category("Tecnología") { Id = Guid.Parse("5cb3774e-88e7-4d69-aac2-38e294f207ec") }
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
