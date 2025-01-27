using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public UpdateSaleHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
        {
            var sale = await _saleRepository.GetByIdAsync(command.Id, cancellationToken);

            if (sale == null)
            {
                return null;
            }

            sale.CustomerId = command.CustomerId;
            sale.TotalAmount = 0;
            sale.IsCancelled = command.IsCancelled;
            sale.SaleDate = command.SaleDate;

            foreach (var itemCommand in command.SaleItems)
            {
                var existingItem = sale.SaleItems.FirstOrDefault(i => i.ProductId == itemCommand.ProductId);

                if (existingItem != null)
                {
                    existingItem.Quantity = itemCommand.Quantity;
                    existingItem.UnitPrice = itemCommand.UnitPrice;
                    existingItem.TotalPrice = itemCommand.Quantity * itemCommand.UnitPrice;
                }
                else
                {
                    var newItem = new SaleItem
                    {
                        ProductId = itemCommand.ProductId,
                        Quantity = itemCommand.Quantity,
                        UnitPrice = itemCommand.UnitPrice,
                        TotalPrice = itemCommand.Quantity * itemCommand.UnitPrice
                    };

                    sale.SaleItems.Add(newItem);
                }

                sale.TotalAmount += itemCommand.Quantity * itemCommand.UnitPrice;
            }

            var productIdsInCommand = command.SaleItems.Select(i => i.ProductId).ToList();
            var itemsToRemove = sale.SaleItems.Where(i => !productIdsInCommand.Contains(i.ProductId)).ToList();
            foreach (var item in itemsToRemove)
            {
                sale.SaleItems.Remove(item);
            }

            await _saleRepository.UpdateAsync(sale, cancellationToken);

            var result = _mapper.Map<UpdateSaleResult>(sale);

            return result;
        }
    }
}
