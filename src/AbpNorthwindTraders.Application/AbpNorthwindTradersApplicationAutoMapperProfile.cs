using AbpNorthwindTraders.Domain.Models;
using AbpNorthwindTraders.Domain.Models.Dtos;
using AutoMapper;

namespace AbpNorthwindTraders
{
    public class AbpNorthwindTradersApplicationAutoMapperProfile : Profile
    {
        public AbpNorthwindTradersApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Employee, EmployeeDto>();
            CreateMap<CreateEmployeeDto, Employee>(MemberList.Source);
            CreateMap<UpdateEmployeeDto, Employee>(MemberList.Source);
        }
    }
}
