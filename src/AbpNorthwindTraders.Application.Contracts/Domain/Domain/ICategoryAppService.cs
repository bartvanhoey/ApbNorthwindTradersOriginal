using System;
using AbpNorthwindTraders.Domain.Domain.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AbpNorthwindTraders.Domain.Domain
{
    public interface ICategoryAppService :
        ICrudAppService< 
            CategoryDto, 
            int, 
            PagedAndSortedResultRequestDto,
            CreateUpdateCategoryDto,
            CreateUpdateCategoryDto>
    {

    }
}