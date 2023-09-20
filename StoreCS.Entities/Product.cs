namespace StoreCS.Entities;

public class Product
{
    public int Id { get; set; }

    public string? Name { get; set; } = string.Empty;
    public ProductCategory? Category { get; set; } 
    public double? Price { get; set; }

    public Guid? VendorCode { get; set; } = Guid.NewGuid();
    
}
