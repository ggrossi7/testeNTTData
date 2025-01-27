namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public string Status { get; set; } = string.Empty;

    public ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
}