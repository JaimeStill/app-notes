namespace AppNotes.Models.Entities;
public class ProductLabel : Label
{
    public int ProductId { get; set; }

    public Product Product { get; set; }
}