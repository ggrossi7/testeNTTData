using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain;

public static class CreateSaleHandlerTestData
{
    public static CreateSaleCommand GenerateValidCommand()
    {
        return new CreateSaleCommand
        {
            SaleItems = new List<SaleItemCommand>
            {
                new SaleItemCommand { ProductId = 1, Quantity = 5, UnitPrice = 20 },
                new SaleItemCommand { ProductId = 2, Quantity = 3, UnitPrice = 30 }
            }
        };
    }

    public static CreateSaleCommand GenerateCommandWithInvalidQuantity()
    {
        return new CreateSaleCommand
        {
            SaleItems = new List<SaleItemCommand>
            {
                new SaleItemCommand { ProductId = 1, Quantity = 25, UnitPrice = 10 }
            }
        };
    }

    public static CreateSaleCommand GenerateValidCommandWithVariousQuantities()
    {
        return new CreateSaleCommand
        {
            SaleItems = new List<SaleItemCommand>
            {
                new SaleItemCommand { ProductId = 1, Quantity = 3, UnitPrice = 20 },
                new SaleItemCommand { ProductId = 2, Quantity = 8, UnitPrice = 30 }
            }
        };
    }
}
