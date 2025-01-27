using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;

namespace Ambev.DeveloperEvaluation.Application.Sales;

public class GetSaleProfile : Profile
{
    public GetSaleProfile()
    {
        CreateMap<GetSaleCommand, Sale>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

        CreateMap<SaleItemResult, SaleItem>();

        CreateMap<Sale, GetSaleResult>()
            .ForMember(dest => dest.SaleItems, opt => opt.MapFrom(src => src.SaleItems));

        CreateMap<SaleItem, SaleItemResult>();
    }
}
