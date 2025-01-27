namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class GetSaleResponse
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }
        public DateTime SaleDate { get; set; }
        public SaleItemResponse[] SaleItems { get; set; } = Array.Empty<SaleItemResponse>();
    }
}
