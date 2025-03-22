using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarService;

public class Service
{
    [ForeignKey("ServiceId")]
    public int ServiceId { get; set; }
    
    [Required]
    [StringLength(100)]
    public string ServiceName { get; set; }
    
    public int ServicePrice { get; set; }
    
    public List<OrderedServices> OrderedServices { get; set; }
}   