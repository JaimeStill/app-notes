namespace AppNotes.Models.Entities;
public class ProductNote : Note
{
    public int ProductId { get; set; }
    
    public Product Product { get; set; }
}