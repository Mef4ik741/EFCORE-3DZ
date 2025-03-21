namespace ConsoleApp5;

public class CarOrder
{
    public int CarId { get; set; }
    public virtual Car Car { get; set; }

    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }
}