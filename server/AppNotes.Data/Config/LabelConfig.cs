using AppNotes.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppNotes.Data.Config;
public class LabelConfig : IEntityTypeConfiguration<Label>
{
    public void Configure(EntityTypeBuilder<Label> builder)
    {
        builder
            .HasDiscriminator(x => x.Type)
            .HasValue<Label>("label")
            .HasValue<ProductLabel>("product");

        builder
            .HasMany(x => x.Notes)
            .WithOne(x => x.Label)
            .HasForeignKey(x => x.LabelId)
            .OnDelete(DeleteBehavior.ClientCascade);
    }
}