using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductGallery.Domain.Entities;
using ProductGallery.Persistence.Data.Seeders;

namespace ProductGallery.Persistence.Data.Config;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.Category)         // Producto tiene una categoría
            .WithMany(p => p.Products)          // Categoria puede tener muchos productos
            .HasForeignKey(p => p.CategoryId);  // A través del identificador

        builder.Property(p => p.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasMaxLength(250)
            .IsRequired(false);

        builder.Property(p => p.ImageUrl)
            .HasMaxLength(250);

        builder.HasData(new ProductSeeder());
    }
}
