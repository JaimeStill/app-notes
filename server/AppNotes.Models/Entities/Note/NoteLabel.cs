namespace AppNotes.Models.Entities;
public class NoteLabel
{
    public int Id { get; set; }
    public int LabelId { get; set; }
    public int NoteId { get; set; }

    public Label Label { get; set; }
    public Note Note { get; set; }
}