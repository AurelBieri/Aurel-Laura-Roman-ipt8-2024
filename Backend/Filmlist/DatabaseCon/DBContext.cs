using Microsoft.EntityFrameworkCore;
using Filmlist.Classes;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id); 

            entity.Property(e => e.Username)
                  .IsRequired()
                  .HasMaxLength(50); 

            entity.Property(e => e.Email)
                  .IsRequired()
                  .HasMaxLength(100);
        });
    }
}
