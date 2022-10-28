using AppNotes.Data;
using AppNotes.Models.Entities;
using AppNotes.Models.Core;

namespace AppNotes.DbCli.Seed;
public class AlbumSeeder : Seeder<Album, AppDbContext>
{
    public AlbumSeeder(AppDbContext db) : base(db) { }

    protected override async Task<List<Album>> Generate()
    {
        Random rnd = new();

        List<Album> albums = new()
        {
            new()
            {
                Creator = "Rivers of Nihil",
                Name = "The Work",
                RecordLabel = "Metal Blade",
                ProductCode = "0039841580020",
                Stock = rnd.Next(20),
                DateReleased = JsDateEncoder.JsDate(2021, 9, 24)
            },
            new()
            {
                Creator = "Tool",
                Name = "10,000 Days",
                RecordLabel = "Volcano",
                ProductCode = "0828768199121",
                Stock = rnd.Next(20),
                DateReleased = JsDateEncoder.JsDate(2006, 5, 2)
            },
            new()
            {
                Creator = "Nirvana",
                Name = "Nevermind",
                RecordLabel = "Geffen Records",
                ProductCode = "0602527779089",
                Stock = rnd.Next(20),
                DateReleased = JsDateEncoder.JsDate(1991, 9, 24)
            },
            new()
            {
                Creator = "Pink Floyd",
                Name = "Dark Side of the Moon",
                RecordLabel = "Capitol",
                ProductCode = "0888751709126",
                Stock = rnd.Next(20),
                DateReleased = JsDateEncoder.JsDate(1973, 3, 1)
            },
            new()
            {
                Creator = "Sevendust",
                Name = "Seasons",
                RecordLabel = "TVT",
                ProductCode = "0016581599024",
                Stock = rnd.Next(20),
                DateReleased = JsDateEncoder.JsDate(2003, 10, 7)
            }
        };

        await db.Albums.AddRangeAsync(albums);
        await db.SaveChangesAsync();

        return albums;
    }
}