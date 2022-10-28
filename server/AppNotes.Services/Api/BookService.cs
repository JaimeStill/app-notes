using AppNotes.Data;
using AppNotes.Models.Entities;
using AppNotes.Models.Validation;

namespace AppNotes.Services.Api;
public class BookService : ProductService<Book>
{
    public BookService(AppDbContext db)
        : base(db) { }

    public override string CreatorLabel { get; } = "Author";
    public override string ProductCodeLabel { get; } = "ISBN";

    protected override Func<IQueryable<Book>, string, IQueryable<Book>> Search =>
        (values, term) =>
            values.Where(x =>
                x.Creator.ToLower().Contains(term.ToLower())
                || x.Name.ToLower().Contains(term.ToLower())
                || x.ProductCode.ToLower().Contains(term.ToLower())
                || x.Publisher.ToLower().Contains(term.ToLower())
            );

    public override async Task<ValidationResult> Validate(Book entity)
    {
        ValidationResult result = await base.Validate(entity);

        if (string.IsNullOrWhiteSpace(entity.Publisher))
            result.AddMessage("Publisher is required");

        if (entity.Pages < 1)
            result.AddMessage("Pages must be greater than one");

        return result;
    }
}