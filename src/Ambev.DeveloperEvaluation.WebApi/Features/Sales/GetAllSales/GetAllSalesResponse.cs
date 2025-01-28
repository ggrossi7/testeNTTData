namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class GetAllSalesResponse
    {
        public List<GetSaleResponse> Sales { get; set; } = new();
    }
}
