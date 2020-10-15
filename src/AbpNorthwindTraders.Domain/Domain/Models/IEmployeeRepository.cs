using System;
using Volo.Abp.Domain.Repositories;

namespace AbpNorthwindTraders.Domain.Models
{
    public interface IEmployeeRepository : IRepository<Employee, int>
    {
    }
}