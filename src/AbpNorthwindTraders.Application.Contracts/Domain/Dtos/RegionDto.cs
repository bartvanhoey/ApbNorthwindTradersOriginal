using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace AbpNorthwindTraders.Domain.Dtos
{
    [Serializable]
    public class RegionDto : FullAuditedEntityDto<int>
    {
        public int Id { get; set; }

        public string RegionDescription { get; set; }

        // public ICollection<Territory> Territories { get; set; }

    }
}