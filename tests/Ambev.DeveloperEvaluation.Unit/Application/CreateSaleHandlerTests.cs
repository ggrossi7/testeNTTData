using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Domain;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

public class CreateSaleHandlerTests
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly CreateSaleHandler _handler;

    public CreateSaleHandlerTests()
    {
        _saleRepository = Substitute.For<ISaleRepository>();
        _mapper = Substitute.For<IMapper>();
        _handler = new CreateSaleHandler(_saleRepository, _mapper);
    }

    [Fact(DisplayName = "Given valid sale data When creating sale Then returns success response")]
    public async Task Handle_ValidRequest_ReturnsSuccessResponse()
    {
        // Given
        var command = CreateSaleHandlerTestData.GenerateValidCommand(); 
        var sale = new Sale
        {
            Id = 1,
            TotalAmount = command.TotalAmount,
            SaleItems = command.SaleItems.Select(item => new SaleItem
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                TotalPrice = item.TotalPrice
            }).ToList()
        };

        var result = new CreateSaleResult
        {
            Id = sale.Id,
            TotalAmount = sale.TotalAmount,
            SaleItems = sale.SaleItems.Select(item => new SaleItemResult
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                TotalPrice = item.TotalPrice
            }).ToArray()
        };

        _mapper.Map<Sale>(command).Returns(sale);
        _mapper.Map<CreateSaleResult>(sale).Returns(result);
        _saleRepository.CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>())
            .Returns(sale);

        // When
        var createSaleResult = await _handler.Handle(command, CancellationToken.None);

        // Then
        createSaleResult.Should().NotBeNull();
        createSaleResult.Id.Should().Be(sale.Id);
        createSaleResult.TotalAmount.Should().Be(sale.TotalAmount);
        createSaleResult.SaleItems.Length.Should().Be(sale.SaleItems.Count);
        await _saleRepository.Received(1).CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
    }

    [Fact(DisplayName = "Given invalid sale data When creating sale Then throws invalid operation exception")]
    public async Task Handle_InvalidRequest_ThrowsInvalidOperationException()
    {
        // Given
        var command = CreateSaleHandlerTestData.GenerateCommandWithInvalidQuantity();

        // When
        var act = () => _handler.Handle(command, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage($"Cannot sell more than 20 items for ProductId {command.SaleItems.First().ProductId}.");
    }

    [Fact(DisplayName = "Given sale items with different quantities When handling Then total price is calculated correctly")]
    public async Task Handle_ValidRequest_CalculatesTotalPriceCorrectly()
    {
        // Given
        var command = CreateSaleHandlerTestData.GenerateValidCommandWithVariousQuantities();
        var sale = new Sale
        {
            Id = 1,
            TotalAmount = command.TotalAmount,
            SaleItems = command.SaleItems.Select(item => new SaleItem
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                TotalPrice = item.Quantity * item.UnitPrice
            }).ToList()
        };

        var result = new CreateSaleResult
        {
            Id = sale.Id,
            TotalAmount = sale.TotalAmount,
            SaleItems = sale.SaleItems.Select(item => new SaleItemResult
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                TotalPrice = item.TotalPrice
            }).ToArray()
        };

        _mapper.Map<Sale>(command).Returns(sale);
        _mapper.Map<CreateSaleResult>(sale).Returns(result);
        _saleRepository.CreateAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>())
            .Returns(sale);

        // When
        var createSaleResult = await _handler.Handle(command, CancellationToken.None);

        // Then
        createSaleResult.SaleItems.First().TotalPrice.Should().Be(60m);
        createSaleResult.TotalAmount.Should().Be(300m);
    }
}
