using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarService;

public class OrderedServices
{
    [Key]
    public int Id { get; set; }
    
    [ForeignKey("OrderId")]
    public int OrderId { get; set; }
    
    [ForeignKey("ServiceId")]
    public int ServiceId { get; set; }
    
    public int Count { get; set; }
    
    public int TotalAmount { get; set;  }
    
    public Order Order { get; set; }

    public Service Service { get; set; }
}