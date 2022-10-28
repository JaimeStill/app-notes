using AppNotes.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppNotes.Data.Config;
public class NoteConfig : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder
            .HasDiscriminator(x => x.Type)
            .HasValue<Note>("note")
            .HasValue<ProductNote>("product");

        builder
            .HasMany(x => x.Labels)
            .WithOne(x => x.Note)
            .HasForeignKey(x => x.NoteId)
            .OnDelete(DeleteBehavior.ClientCascade);
    }
}