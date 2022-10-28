namespace AppNotes.Models.Entities;
public class Book : Product
{
    public int Pages { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }
    public string DatePublished { get; set; }
}