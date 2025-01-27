namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class GetSaleResult
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }
        public DateTime SaleDate { get; set; }
        public SaleItemResult[] SaleItems { get; set; } = Array.Empty<SaleItemResult>();
    }
}
