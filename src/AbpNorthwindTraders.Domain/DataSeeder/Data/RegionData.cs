using System.Collections.Generic;

namespace AbpNorthwindTraders.Domain.DataSeeder.Data
{
  public static class RegionData
  {
    public static readonly List<Region> Regions = new List<Region>();

    public static void AddRegions()
    {
      Regions.AddRange(new[]
      {
                new Region {Id = 1, RegionDescription = "Eastern"},
                new Region {Id = 2, RegionDescription = "Western"},
                new Region {Id = 3, RegionDescription = "Northern"},
                new Region {Id = 4, RegionDescription = "Southern"}
            });
    }
  }
}