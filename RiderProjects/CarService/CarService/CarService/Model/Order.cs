using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarService;

public class Order
{
    [Key]
    public int Id { get; set; }
    
    [ForeignKey("CustomerId")]
    public int CustomerId { get; set; }
    
    [ForeignKey("CarId")]
    public int CarId { get; set; }
    
    [Required]
    public DateTime OrderDate { get; set; }
   
    [Required]
    public bool Status { get; set; } = false;
    
    public Customer Customer { get; set; }
    
    public Car Car { get; set; }
    
    public ICollection<OrderedServices> OrderedServices { get; set; }

}