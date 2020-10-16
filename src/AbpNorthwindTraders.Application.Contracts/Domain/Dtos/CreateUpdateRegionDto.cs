using System;
using System.ComponentModel;
namespace AbpNorthwindTraders.Domain.Dtos
{
    [Serializable]
    public class CreateUpdateRegionDto
    {
        public int Id { get; set; }

        public string RegionDescription { get; set; }

        // public ICollection<Territory> Territories { get; set; }

    }
}