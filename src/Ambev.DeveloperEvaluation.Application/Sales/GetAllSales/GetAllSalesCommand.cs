using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetAllSalesCommand : IRequest<List<GetSaleResult>>
    {
        
    }
}
