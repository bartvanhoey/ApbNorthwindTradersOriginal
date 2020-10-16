using System;
using Volo.Abp.Domain.Repositories;

namespace AbpNorthwindTraders.Domain.Domain
{
    public interface ISupplierRepository : IRepository<Supplier, int>
    {
    }
}