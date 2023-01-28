using ProductGallery.Domain.Entities;
using System.Collections;

namespace ProductGallery.Persistence.Data.Seeders;

internal class ProductSeeder : IEnumerable<Product>
{
    readonly List<Product> productlist = new()
        {
            new Product("Iphone") { Category = new Category("Tecnología")},
            //new Product("Libro"),
            //new Product("Computador"),
            //new Product("Monitor"),
            //new Product("Cuchara"),
            //new Product("Mario Kart"),
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
