namespace StoreCS.Entities;

public class Order
{
    public int Id { get; set; }
    public DateTime? BoughtDate { get; set; }
    public double? TotalPrice { get; set; }

    public List<OrderItem>? OrderItems { get; set; }
}
