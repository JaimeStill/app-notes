using AppNotes.Data;
using AppNotes.Models.Entities;
using AppNotes.Models.Core;

namespace AppNotes.DbCli.Seed;
public class BookSeeder : Seeder<Book, AppDbContext>
{
    public BookSeeder(AppDbContext db) : base(db) { }

    protected override async Task<List<Book>> Generate()
    {
        Random rnd = new();

        List<Book> books = new()
        {
            new()
            {
                Creator = "Stephen King",
                Name = "The Shining",
                Publisher = "Knopf Doubleday Publishing Group",
                Pages = 447,
                ProductCode = "9780345806789",
                Stock = rnd.Next(20),
                DateReleased = JsDateEncoder.JsDate(1977, 1, 28)                
            },
            new()
            {
                Creator = "Mark Z. Danielewski",
                Name = "House of Leaves",
                Publisher = "Knopf Doubleday Publishing Group",
                Pages = 736,
                ProductCode = "9780375703768",
                Stock = rnd.Next(20),
                DateReleased = JsDateEncoder.JsDate(2000, 3, 7)
            },
            new()
            {
                Creator = "Chuck Palahniuk",
                Name = "Fight Club: A Novel",
                Publisher = "Norton, W. W. & Company, Inc.",
                Pages = 224,
                ProductCode = "9780393355949",
                Stock = rnd.Next(20),
                DateReleased = JsDateEncoder.JsDate(1996, 8, 17)
            },
            new()
            {
                Creator = "Orson Scott Card",
                Name = "Ender's Game",
                Publisher = "Tom Doherty Associates",
                Pages = 352,
                ProductCode = "9780812550702",
                Stock = rnd.Next(20),
                DateReleased = JsDateEncoder.JsDate(1994, 7, 15)
            },
            new()
            {
                Creator = "George R. R. Martin",
                Name = "A Game of Thrones: The Illustrated Edition (A Song of Ice and Fire #1)",
                Publisher = "Random House Publishing Group",
                Pages = 896,
                ProductCode = "9780553808049",
                Stock = rnd.Next(20),
                DateReleased = JsDateEncoder.JsDate(2016, 10, 18)
            }
        };

        await db.Books.AddRangeAsync(books);
        await db.SaveChangesAsync();
        
        return books;
    }
}