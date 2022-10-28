using AppNotes.Data;
using AppNotes.Models.Entities;
using AppNotes.Models.Validation;

namespace AppNotes.Services.Api;
public class AlbumService : ProductService<Album>
{
    public AlbumService(AppDbContext db)
        : base(db) { }

    public override string CreatorLabel { get; } = "Artist";
    public override string ProductCodeLabel { get; } = "UPC";

    protected override Func<IQueryable<Album>, string, IQueryable<Album>> Search =>
        (values, term) =>
            values.Where(x =>
                x.Creator.ToLower().Contains(term.ToLower())
                || x.Name.ToLower().Contains(term.ToLower())
                || x.ProductCode.ToLower().Contains(term.ToLower())
                || x.RecordLabel.ToLower().Contains(term.ToLower())
            );

    public override async Task<ValidationResult> Validate(Album entity)
    {
        ValidationResult result = await base.Validate(entity);

        if (string.IsNullOrWhiteSpace(entity.RecordLabel))
            result.AddMessage("Record Label is required");

        return result;
    }
}