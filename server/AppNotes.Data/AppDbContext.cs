using AppNotes.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace AppNotes.Data;
public class AppDbContext : DbContext
{
    public DbSet<Album> Albums { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Label> Labels { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<NoteLabel> NoteLabels { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductLabel> ProductLabels { get; set; }
    public DbSet<ProductNote> ProductNotes { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        SavingChanges += CompleteEntity;
    }

    private IEnumerable<EntityEntry> ChangeTrackerEntities() =>
        ChangeTracker
            .Entries()
            .Where(x => x.Entity is Entity);

    private bool EntitiesChanged() =>
        ChangeTrackerEntities().Any();

    private void CompleteEntity(object sender, SavingChangesEventArgs e)
    {
        if (EntitiesChanged())
        {
            var entities = ChangeTrackerEntities()
                .Select(x => x.Entity)
                .Cast<Entity>();

            foreach (Entity entity in entities)
                entity.Complete();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly()
        );

        modelBuilder
            .Model
            .GetEntityTypes()
            .Where(x => x.BaseType == null)
            .ToList()
            .ForEach(x =>
                modelBuilder
                    .Entity(x.Name)
                    .ToTable(x.DisplayName())
            );
    }
}