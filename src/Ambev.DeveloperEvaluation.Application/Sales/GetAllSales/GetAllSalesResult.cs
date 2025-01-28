namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class GetAllSalesResult
    {
        public int TotalCount { get; set; }
        public List<GetSaleResult> Sales { get; set; } = new List<GetSaleResult>();
    }
}
