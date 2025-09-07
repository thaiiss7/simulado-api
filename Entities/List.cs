namespace simulado.Entities;

public class List
{
    public Guid ID { get; set; }
    public string Title { get; set; }
    public DateTime LastUpdated { get; set; }
    public ICollection<Story> Stories { get; set; } = [];
    public Profile Owner { get; set; }
    public Guid OwnerId { get; set; }
}