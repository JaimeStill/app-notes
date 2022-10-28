namespace AppNotes.Models.Entities;
public class Label : Entity
{
    public string Type { get; set; }
    public string Description { get; set; }
    public string Foreground { get; set; }
    public string Background { get; set; }

    public ICollection<NoteLabel> Notes { get; set; }
}