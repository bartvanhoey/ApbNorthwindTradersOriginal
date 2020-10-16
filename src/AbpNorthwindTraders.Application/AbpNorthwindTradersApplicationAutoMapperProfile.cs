using AbpNorthwindTraders.Domain;
using AbpNorthwindTraders.Domain.Dtos;
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
            CreateMap<CreateUpdateEmployeeDto, Employee>(MemberList.Source);
            CreateMap<Region, RegionDto>();
            CreateMap<CreateUpdateRegionDto, Region>(MemberList.Source);
            CreateMap<Territory, TerritoryDto>();
            CreateMap<CreateUpdateTerritoryDto, Territory>(MemberList.Source);
        }
    }
}
