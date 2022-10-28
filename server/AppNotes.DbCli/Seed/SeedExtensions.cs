using AppNotes.Data;

namespace AppNotes.DbCli.Seed;
public static class SeedExtensions
{
    public static async Task Seed(this AppDbContext db)
    {
        Console.WriteLine($"Seeding {db.Database.ProviderName}");
        await Task.CompletedTask;        
    }
}