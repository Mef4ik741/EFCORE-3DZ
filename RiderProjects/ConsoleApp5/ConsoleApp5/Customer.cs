using System.ComponentModel.DataAnnotations;

namespace ConsoleApp5;

public class Customer
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public virtual ICollection<CarOrder> CarOrders { get; set; }
}
