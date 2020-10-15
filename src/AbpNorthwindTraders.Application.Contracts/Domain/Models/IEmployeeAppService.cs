using System;
using AbpNorthwindTraders.Domain.Models.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AbpNorthwindTraders.Domain.Models
{
    public interface IEmployeeAppService :
        ICrudAppService< 
            EmployeeDto, 
            int, 
            PagedAndSortedResultRequestDto,
            CreateEmployeeDto,
            UpdateEmployeeDto>
    {

    }
}