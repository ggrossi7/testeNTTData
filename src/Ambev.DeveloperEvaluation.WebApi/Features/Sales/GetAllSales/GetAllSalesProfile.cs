using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales
{
    public class GetAllSalesProfile : Profile
    {
        public GetAllSalesProfile()
        {
            CreateMap<GetAllSalesRequest, GetAllSalesCommand>();

            CreateMap<GetAllSalesResult, GetAllSalesResponse>()
                .ForMember(dest => dest.Sales, opt => opt.MapFrom(src => src.Sales));

            CreateMap<SaleItemResult, SaleItemResponse>();
        }
    }
}
