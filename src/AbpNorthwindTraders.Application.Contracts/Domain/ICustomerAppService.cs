using System;
using AbpNorthwindTraders.Domain.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AbpNorthwindTraders.Domain
{
    public interface ICustomerAppService :
        ICrudAppService< 
            CustomerDto, 
            string, 
            PagedAndSortedResultRequestDto,
            CreateUpdateCustomerDto,
            CreateUpdateCustomerDto>
    {

    }
}