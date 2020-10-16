using System;
using System.ComponentModel;
namespace AbpNorthwindTraders.Domain.Dtos
{
    [Serializable]
    public class CreateUpdateTerritoryDto
    {
        public string Id { get; set; }

        public string TerritoryDescription { get; set; }

        public int RegionId { get; set; }

        // public Region Region { get; set; }

        // public ICollection<EmployeeTerritory> EmployeeTerritories { get; set; }

    }
}