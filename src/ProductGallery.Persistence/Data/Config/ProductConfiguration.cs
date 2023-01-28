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

        //builder.HasOne(p => p.Category).WithMany(p => p.Products).HasForeignKey(p => p.Id);

        builder.Property(p => p.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasMaxLength(250);

        builder.Property(p => p.Image)
            .HasMaxLength(250);

        builder.HasData(new ProductSeeder());
    }
}
