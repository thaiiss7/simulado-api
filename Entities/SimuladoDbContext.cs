using Microsoft.EntityFrameworkCore;

namespace Simulado.Entities;

public class SimuladoDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Profile> Profiles => Set<Profile>();
    public DbSet<Story> Stories => Set<Story>();
    public DbSet<List> Lists => Set<List>();

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Profile>();

        model.Entity<Story>()
            .HasOne(s => s.Author)
            .WithMany(p => p.Stories)
            .HasForeignKey(s => s.AuthorId)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<List>()
            .HasOne(l => l.Owner)
            .WithMany(p => p.Lists)
            .HasForeignKey(l => l.OwnerId)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<List>()
            .HasMany(l => l.Stories)
            .WithMany(s => s.Lists)
            .UsingEntity("StoryList");
    }
}