namespace StoreCS.Entities;

public class Order
{
    public int Id { get; set; }
    public DateTime BoughtData { get; set; }
    public double TotalPrice { get; set; }

    public List<Product> Products { get; set; } 
}
