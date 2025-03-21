using System.ComponentModel.DataAnnotations;

namespace ConsoleApp5;

public class Dealer
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Location { get; set; } 
    
    public virtual ICollection<Car> Cars { get; set; }
}
