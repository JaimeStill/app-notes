namespace AppNotes.Models.Entities;
public class Note : Entity
{
    public string Type { get; set; }
    public string Value { get; set; }

    public ICollection<NoteLabel> Labels { get; set; }
}