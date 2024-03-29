using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name).HasMaxLength(100).IsRequired();
        builder.Property(t => t.Description).HasMaxLength(2200).IsRequired();
        builder.Property(t => t.Price).HasPrecision(10, 2).IsRequired();

        builder.Property<Guid>("CategoryId");
        builder.HasOne(t => t.Category).WithMany(t => t.Products).HasForeignKey("Id");
    }
}
