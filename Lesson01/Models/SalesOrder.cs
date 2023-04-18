namespace Lesson01.Models;

public class SalesOrder
{
    public string ProductId { get; set; } = null!;
    public double Price { get; set; }
    public int Qty { get; set; }
}
