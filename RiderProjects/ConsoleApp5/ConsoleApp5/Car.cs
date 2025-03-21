using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp5;
public class Car
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Make { get; set; }

    [Required]
    public string Model { get; set; }

    [Range(1900, 2100)]
    public int Year { get; set; }

    public int DealerId { get; set; }
    
    public virtual Dealer Dealer { get; set; }
    public virtual ICollection<CarOrder> CarOrders { get; set; }

    
    public bool IsDeleted { get; set; } = false;
    
    public Car(){}
}
