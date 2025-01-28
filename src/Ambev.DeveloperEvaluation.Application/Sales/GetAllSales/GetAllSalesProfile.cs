using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;

namespace Ambev.DeveloperEvaluation.Application.Sales;

public class GetAllSalesProfile : Profile
{
    public GetAllSalesProfile()
    {
        CreateMap<Sale, GetSaleResult>()
            .ForMember(dest => dest.SaleItems, opt => opt.MapFrom(src => src.SaleItems));

        CreateMap<GetAllSalesCommand, Sale>();

        CreateMap<List<Sale>, GetAllSalesResult>()
            .ForMember(dest => dest.Sales, opt => opt.MapFrom(src => src));

        CreateMap<SaleItem, SaleItemResult>();
    }
}
