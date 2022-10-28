using AppNotes.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppNotes.Data.Config;
public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .HasDiscriminator(x => x.Type)
            .HasValue<Product>("product")
            .HasValue<Album>("album")
            .HasValue<Book>("book");

        builder
            .HasMany(x => x.Labels)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId);

        builder
            .HasMany(x => x.Notes)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId);
    }
}