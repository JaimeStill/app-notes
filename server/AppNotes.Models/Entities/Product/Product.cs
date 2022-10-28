namespace AppNotes.Models.Entities;
public class Product : Entity
{
    public int Stock { get; set; }
    public string Type { get; set; }
    public string Creator { get; private set; }
    public string ProductCode { get; set; }
    public string Link { get; private set; }
    public string Image { get; private set; }

    public ICollection<ProductLabel> Labels { get; set; }
    public ICollection<ProductNote> Notes { get; set; }

    public override void Complete()
    {
        base.Complete();
        Link = $"https://www.barnesandnoble.com/s/{ProductCode}";
        Image = $"https://prodimage.images-bn.com/pimages/{ProductCode}";
    }
}