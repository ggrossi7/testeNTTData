using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales
{
    public class CreateSaleProfile : Profile
    {
        public CreateSaleProfile()
        {
            CreateMap<CreateSaleRequest, CreateSaleCommand>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.SaleDate, opt => opt.MapFrom(src => src.SaleDate))
                .ForMember(dest => dest.SaleItems, opt => opt.MapFrom(src => src.SaleItems));

            CreateMap<SaleItemRequest, SaleItemCommand>();

            CreateMap<CreateSaleResult, CreateSaleResponse>()
                .ForMember(dest => dest.SaleItems, opt => opt.MapFrom(src => src.SaleItems));

            CreateMap<SaleItemResult, SaleItemResponse>();
        }
    }
}