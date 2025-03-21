using ConsoleApp5;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class ApplicationDbContext : DbContext
{
    private string connectionString = "Data Source=localhost; Initial Catalog=CarsDBW; Trust Server Certificate=true; Integrated Security=True;";

    public DbSet<Car> Cars { get; set; }
    public DbSet<Dealer> Dealers { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CarOrder> CarOrders { get; set; }

    private static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddConsole();
    });

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        FileLogger.Log("Настройка базы данных...");

        optionsBuilder
            .UseSqlServer(connectionString, options => options.EnableRetryOnFailure())
            .EnableSensitiveDataLogging();

        FileLogger.Log("База данных настроена.");
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>()
            .HasIndex(c => new { c.Make, c.Model })
            .IsUnique();

        modelBuilder.Entity<CarOrder>()
            .HasKey(co => new { co.CarId, co.CustomerId });

        modelBuilder.Entity<CarOrder>()
            .HasOne(co => co.Car)
            .WithMany(c => c.CarOrders)
            .HasForeignKey(co => co.CarId);

        modelBuilder.Entity<CarOrder>()
            .HasOne(co => co.Customer)
            .WithMany(cu => cu.CarOrders)
            .HasForeignKey(co => co.CustomerId);
    }
}