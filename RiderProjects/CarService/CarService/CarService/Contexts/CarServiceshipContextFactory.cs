using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CarService;

public class CarServiceshipContextFactory : IDesignTimeDbContextFactory<CarServiceContext>
{
    private string connectionString = "Data Source=localhost;Initial Catalog=CarService;Integrated Security=True;TrustServerCertificate=True";


    public CarServiceContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CarServiceContext>();
        optionsBuilder.UseSqlServer(connectionString); 
        
        return new CarServiceContext(optionsBuilder.Options);
    }
}   
