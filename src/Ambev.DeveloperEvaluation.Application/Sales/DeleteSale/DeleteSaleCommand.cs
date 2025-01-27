using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class DeleteSaleCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
