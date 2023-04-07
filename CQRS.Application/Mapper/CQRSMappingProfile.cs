using AutoMapper;
using CQRS.Application.Commands;
using CQRS.Application.Responses;
using CQRS.Core.Entities;

namespace CQRS.Application.Mapper
{
    public class CQRSMappingProfile : Profile
    {
        public CQRSMappingProfile()
        {
            CreateMap<Customer, CustomerResponse>().ReverseMap();
            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
            CreateMap<Customer, EditCustomerCommand>().ReverseMap();
        }
    }
}