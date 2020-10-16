using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbpNorthwindTraders.Domain;
using AbpNorthwindTraders.Domain.DataSeeder.Data;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace AbpNorthwindTraders.Domain.DataSeeder
{
  public class Seeder : IDataSeedContributor, ITransientDependency
  {
    private readonly IRepository<Employee, int> _employeeRepository;
    private readonly IRepository<Region, int> _regionRepository;
    private readonly IRepository<Territory, string> _territoryRepository;
    private readonly IRepository<Customer, string> _customerRepository;
    private readonly IRepository<Supplier, int> _supplierRepository;

    public Seeder(IRepository<Employee, int> employeeRepository, IRepository<Region, int> regionRepository, IRepository<Territory, string> territoryRepository, IRepository<Customer, string> customerRepository, IRepository<Supplier, int> supplierRepository)
    {
      this._employeeRepository = employeeRepository;
      _regionRepository = regionRepository;
      _territoryRepository = territoryRepository;
      this._customerRepository = customerRepository;
      this._supplierRepository = supplierRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
      //  Seed Regions
      if (await _regionRepository.GetCountAsync() <= 0)
      {
        RegionData.AddRegions();
        foreach (var region in RegionData.Regions)
        {
          await _regionRepository.InsertAsync(region);
        }
      }

      //   Seed Territories
      if (await _regionRepository.GetCountAsync() <= 0)
      {
        TerritoryData.AddTerritories();
        foreach (var territory in TerritoryData.Territories)
        {
          await _territoryRepository.InsertAsync(territory);
        }
      }

      // Seed Employees
      if (await _employeeRepository.GetCountAsync() <= 0)
      {
        EmployeeData.AddEmployees();
        foreach (var employee in EmployeeData.Employees.Values)
        {
          await _employeeRepository.InsertAsync(employee);
        }
      }

      // Seed Customers
      if (await _customerRepository.GetCountAsync() <= 0)
      {
        CustomerData.AddCustomers();
        foreach (var customer in CustomerData.Customers)
        {
          await _customerRepository.InsertAsync(customer);
        }
      }

      // Seed Suppliers
      if (await _supplierRepository.GetCountAsync() <= 0)
      {
        SupplierData.AddSuppliers();
        foreach (var supplier in SupplierData.Suppliers.Values)
        {
          await _supplierRepository.InsertAsync(supplier);
        }
      }
    }




  }
}