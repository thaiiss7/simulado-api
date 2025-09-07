namespace Simulado.Entities;

public class Story
{
    public Guid ID { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public Guid AuthorId { get; set; }
    public Profile Author { get; set; }
    public ICollection<List> Lists { get; set; } = []; //listas que contem essa historia
}