namespace simulado.Entities;

public class Profile
{
    public Guid ID { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string? Bio { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<List>? Lists { get; set; } = []; //listas criadas pelo usuario
    public ICollection<Story>? Stories { get; set; } = []; //historias criadas pelo usuario
}