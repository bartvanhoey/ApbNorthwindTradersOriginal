using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace AbpNorthwindTraders.Domain.DataSeeder
{
  public class RegionsSeeder : IDataSeedContributor, ITransientDependency
  {
    private readonly IRepository<Region, int> _repository;
    public readonly List<Region> Regions = new List<Region>();

    public RegionsSeeder(IRepository<Region, int> repository) => _repository = repository;

    public async Task SeedAsync(DataSeedContext context)
    {
      if (await _repository.GetCountAsync() <= 0)
      {
          AddRegions();
        foreach (var region in Regions)
        {
          await _repository.InsertAsync(region);
        }
      }
    }

    private void AddRegions()
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