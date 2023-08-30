using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Models
{

public class AppDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<LibraryCard> LibraryCards { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasOne(b => b.LibraryCard)
            .WithOne(lc => lc.Book)
            .HasForeignKey<Book>(b => b.LibraryCardId);

        modelBuilder.Entity<LibraryCard>()
            .HasMany(lc => lc.Books)
            .WithOne(b => b.LibraryCard)
            .HasForeignKey(b => b.LibraryCardId);
    }
}
}