using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CarService;

public class CarServiceContext : DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Customer> Customers { get; set; }
    
    public DbSet<Admin> Admins { get; set; }
    
    public DbSet<OrderedServices> OrderedServices { get; set; }
    
    public CarServiceContext(DbContextOptions<CarServiceContext> options) : base(options) { }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    { 
        if (!optionsBuilder.IsConfigured) 
        { 
            var conString = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json")
                .Build()
                .GetConnectionString("Default");

            optionsBuilder.UseSqlServer(conString);
        }
    }
    
    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(
            new Customer 
            { 
                Id = 1, 
                Name = "Иван", 
                Surname = "Иванов", 
                Phone = "123-456-789",
                Login = "ivanov",
                Password = "password123"
            },
            new Customer 
            { 
                Id = 2, 
                Name = "Петр", 
                Surname = "Петров", 
                Phone = "987-654-321",
                Login = "petrov",
                Password = "password456"
            }
        );

        modelBuilder.Entity<Car>().HasData(
            new Car { Id = 1, Brand = "Toyota", Model = "Corolla", Year = 2020, CustomerId = 1 },
            new Car { Id = 2, Brand = "Honda", Model = "Civic", Year = 2021, CustomerId = 2 }
        );

        modelBuilder.Entity<Service>().HasData(
            new Service { ServiceId = 1, ServiceName = "Замена масла", ServicePrice = 1500 },
            new Service { ServiceId = 2, ServiceName = "Плановое обслуживание", ServicePrice = 3000 },
            new Service { ServiceId = 3, ServiceName = "Ремонт двигателя", ServicePrice = 10000 }
        );

        modelBuilder.Entity<Order>().HasData(
            new Order { Id = 1, CustomerId = 1, CarId = 1, OrderDate = DateTime.Now, Status = "В процессе" },
            new Order { Id = 2, CustomerId = 2, CarId = 2, OrderDate = DateTime.Now, Status = "Завершен" }
        );

        modelBuilder.Entity<OrderedServices>().HasData(
            new OrderedServices { Id = 1, OrderId = 1, ServiceId = 1, Count = 2, TotalAmount = 3000 },
            new OrderedServices { Id = 2, OrderId = 2, ServiceId = 2, Count = 1, TotalAmount = 3000 }
        );
    }*/
}