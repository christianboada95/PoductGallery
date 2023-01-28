using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductGallery.Domain.Entities;
using ProductGallery.Persistence.Data.Seeders;

namespace ProductGallery.Persistence.Data.Config
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id).IsUnique();

            builder.Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasData(new CategorySeeder());
        }
    }
}
