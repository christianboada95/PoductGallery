using ProductGallery.Domain.Entities;
using System.Collections;

namespace ProductGallery.Persistence.Data.Seeders;

internal class ProductSeeder : IEnumerable<Product>
{
    readonly List<Product> productlist = new()
        {
            new Product("Iphone") { CategoryId = Guid.Parse("5cb3774e-88e7-4d69-aac2-38e294f207ec") },
            new Product("Libro") { CategoryId = Guid.Parse("a1ff8e63-2c4d-46b4-a684-595d389be365") },
            new Product("Computador") { CategoryId = Guid.Parse("a422b632-e3da-480f-b237-c551b14f84c0") },
            new Product("Monitor") { CategoryId = Guid.Parse("a422b632-e3da-480f-b237-c551b14f84c0") },
            new Product("Cuchara") { CategoryId = Guid.Parse("a4745a21-cd2a-4b95-bc0b-a7ec9b12434f") },
            new Product("Mario Kart") { CategoryId = Guid.Parse("47ae148e-3623-46ba-a13e-995937216853") }
        };

    public IEnumerator<Product> GetEnumerator()
    {
        return productlist.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
