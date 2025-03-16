using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarService;

public class Car
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Brand { get; set; }
    
    [Required]
    public string Model { get; set; }

    public int Year { get; set; }
    
    [ForeignKey("CustomerId")]
    public int CustomerId { get; set; }
    
    public Customer Customer { get; set; }
}