namespace AppNotes.Models.Entities;
public class Label : Entity
{
    public int EntityId { get; set; }
    public string Description { get; set; }
    public string Foreground { get; set; }
    public string Background { get; set; }

    public Entity Entity { get; set; }
}