using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

namespace Ambev.DeveloperEvaluation.Application.Sales;

public class CreateSaleProfile : Profile
{
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleCommand, Sale>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.SaleDate, opt => opt.MapFrom(src => src.SaleDate))
                .ForMember(dest => dest.SaleItems, opt => opt.MapFrom(src => src.SaleItems));

        CreateMap<SaleItemCommand, SaleItem>();

        CreateMap<Sale, CreateSaleResult>()
            .ForMember(dest => dest.SaleItems, opt => opt.MapFrom(src => src.SaleItems));

        CreateMap<SaleItem, SaleItemResult>();
    }
}