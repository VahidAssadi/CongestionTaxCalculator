using Microsoft.EntityFrameworkCore;

public class CongestionTaxContext : DbContext
{
    public DbSet<TollRecord> TollRecords { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("InMemoryTollDB");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TollRecord>().HasKey(tr => tr.Id);
        modelBuilder.Entity<TollRecord>().OwnsOne(tr => tr.Vehicle);

    }
}
