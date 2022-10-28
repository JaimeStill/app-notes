using AppNotes.Data;
using AppNotes.Models.Entities;
using AppNotes.Models.Validation;
using Microsoft.EntityFrameworkCore;

namespace AppNotes.Services.Api;
public abstract class ProductService<T> : EntityService<T> where T : Product
{
    public ProductService(AppDbContext db)
        : base(db) { }

    public virtual string CreatorLabel { get; } = "Creator";
    public virtual string ProductCodeLabel { get; } = "Product Code";

    public override async Task<bool> ValidateName(T entity) =>
        !await db.Set<T>()
            .AnyAsync(x =>
                x.Id != entity.Id
                && x.Name.ToLower() == entity.Name.ToLower()
                && x.Creator.ToLower() == entity.Creator.ToLower()
            );

    public override async Task<ValidationResult> Validate(T entity)
    {
        ValidationResult result = await base.Validate(entity);

        if (string.IsNullOrWhiteSpace(entity.Creator))
            result.AddMessage($"{CreatorLabel} is required");

        if (string.IsNullOrWhiteSpace(entity.ProductCode))
            result.AddMessage($"{ProductCodeLabel} is required");

        if (string.IsNullOrWhiteSpace(entity.DateReleased))
            result.AddMessage("Release Date is required");

        if (entity.Stock < 0)
            result.AddMessage("Stock must be greater than zero");

        return result;
    }
}