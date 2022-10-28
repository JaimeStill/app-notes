namespace AppNotes.Models.Entities;
public class Album : Product
{
    public string Artist { get; set; }
    public string Label { get; set; }
    public string DateReleased { get; set; }
}