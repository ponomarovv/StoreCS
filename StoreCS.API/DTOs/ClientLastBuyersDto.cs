namespace StoreCS.API.DTOs;

public class ClientLastBuyersDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime? LastPurchaseDate { get; set; }
}
