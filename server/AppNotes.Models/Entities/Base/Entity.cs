using AppNotes.Models.Core;

namespace AppNotes.Models.Entities;
public abstract class Entity
{
    public int Id { get; set; }
    public string Url { get; private set; }
    public string Name { get; set; }
    public string DateCreated { get; set; }
    public string LastModified { get; set; }
    
    protected static string Encode(string prop) => UrlEncoder.Encode(prop);

    public virtual void Complete()
    {
        if (string.IsNullOrWhiteSpace(DateCreated))
            DateCreated = LastModified = JsDateEncoder.JsDate(DateTime.Now);
        else
            LastModified = JsDateEncoder.JsDate(DateTime.Now);

        Url = Encode(Name);
    }
}