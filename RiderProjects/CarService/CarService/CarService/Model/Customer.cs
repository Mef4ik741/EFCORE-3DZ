using System.ComponentModel.DataAnnotations;

namespace CarService;

public class Customer
{
    [Key]
    public int Id { get; set; }
 
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Surname { get; set; }
    
    [Required]
    public string Phone { get; set; }
    
    [Required] 
    public string Login { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    public ICollection<Car> Cars { get; set; }

    public List<Order> Orders { get; set; }
}