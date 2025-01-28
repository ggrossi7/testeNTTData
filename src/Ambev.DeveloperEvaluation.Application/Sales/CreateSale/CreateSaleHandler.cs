using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
        {
            foreach (var item in command.SaleItems)
            {
                if (item.Quantity < 4)
                {
                    item.TotalPrice = item.Quantity * item.UnitPrice;
                }
                else if (item.Quantity >= 4 && item.Quantity < 10)
                {
                    item.TotalPrice = item.Quantity * item.UnitPrice * 0.90m;
                }
                else if (item.Quantity >= 10 && item.Quantity <= 20)
                {
                    item.TotalPrice = item.Quantity * item.UnitPrice * 0.80m;
                }
                else
                {
                    throw new InvalidOperationException($"Cannot sell more than 20 items for ProductId {item.ProductId}.");
                }
            }

            var totalAmount = command.SaleItems.Sum(i => i.TotalPrice);
            command.TotalAmount = totalAmount;

            var sale = _mapper.Map<Sale>(command);
            var createdSale = await _saleRepository.CreateAsync(sale, cancellationToken);
            var result = _mapper.Map<CreateSaleResult>(createdSale);

            result.TotalAmount = createdSale.SaleItems.Sum(i => i.TotalPrice);

            return result;
        }
    }
}
