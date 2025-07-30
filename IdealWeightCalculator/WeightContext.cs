using Microsoft.EntityFrameworkCore;

namespace IdealWeightCalculator;

public class WeightContext : DbContext
{
    public DbSet<User> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=DESKTOP-G46T0HK\SQLEXPRESS;Database=Weights_Database;Integrated Security=True;TrustServerCertificate=True;");
    }

}

