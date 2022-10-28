namespace AppNotes.Models.Entities;
public class Note : Entity
{
    public int EntityId { get; set; }
    public string Value { get; set; }

    public Entity Entity { get; set; }
}