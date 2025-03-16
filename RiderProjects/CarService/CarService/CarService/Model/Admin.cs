using System.ComponentModel.DataAnnotations;

namespace CarService;

public class Admin
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string AdminName { get; set; }
    
    [Required]
    public string AdminSurname { get; set; }
    
    [Required]
    public string Login { get; set; }
    [Required]
    public string Password { get; set; }
}