using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale
{
    public int Id { get; set; }
    public DateTime SaleDate { get; set; }
    public int CustomerId { get; set; }
    public decimal TotalAmount { get; set; }
    public bool IsCancelled { get; set; }
    public Customer? Customer { get; set; }

    public ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
}