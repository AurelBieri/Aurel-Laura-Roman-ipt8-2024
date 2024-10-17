using Microsoft.EntityFrameworkCore;
using Filmlist.Classes;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<MovieList> MovieLists { get; set; }
    public DbSet<MovieItem> MovieItems { get; set; }

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

        modelBuilder.Entity<MovieList>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.User)
                  .WithMany(u => u.MovieLists) 
                  .HasForeignKey(e => e.UserId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.CreatedAt)
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.Property(e => e.UpdatedAt)
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<MovieItem>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.MovieList)
                  .WithMany(ml => ml.Movies) 
                  .HasForeignKey(e => e.MovieListId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.Property(e => e.Title)
                  .IsRequired()
                  .HasMaxLength(255);

            entity.Property(e => e.IsWatched)
                  .HasDefaultValue(false);
        });
    }
}
