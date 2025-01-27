namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class UpdateSaleRequest
    {
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }
        public DateTime SaleDate { get; set; }
        public SaleItemRequest[] SaleItems { get; set; } = Array.Empty<SaleItemRequest>();
    }
}
