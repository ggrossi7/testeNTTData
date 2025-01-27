using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleCommand : IRequest<CreateSaleResult>
    {
        public DateTime SaleDate { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }
       
        public List<SaleItemCommand> SaleItems { get; set; } = new List<SaleItemCommand>();
    }

    public class SaleItemCommand
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class ValidationResultDetail
    {
        public bool IsValid { get; set; }
        public IEnumerable<ValidationErrorDetail> Errors { get; set; } = new List<ValidationErrorDetail>();
    }

    public class ValidationErrorDetail
    {
        public string? PropertyName { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
