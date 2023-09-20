namespace StoreCS.Entities;

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public ProductCategory Category { get; set; } 
    public double Price { get; set; }

    public int Amount { get; set; } = 1;

    public Guid VendorCode { get; set; } = Guid.NewGuid();

    public List<Order> Orders { get; set; }
}
