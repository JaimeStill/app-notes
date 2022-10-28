using AppNotes.Data;

namespace AppNotes.DbCli.Seed;
public static class SeedExtensions
{
    public static async Task Seed(this AppDbContext db)
    {
        Console.WriteLine("Seeding Albums");
        AlbumSeeder albumSeeder = new(db);
        await albumSeeder.Seed();

        Console.WriteLine("Seeding Books");
        BookSeeder bookSeeder = new(db);
        await bookSeeder.Seed();
    }
}