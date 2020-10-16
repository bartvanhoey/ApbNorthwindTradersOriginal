using System.Threading.Tasks;
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
    private readonly IRepository<Category, int> _categoryRepository;
    private readonly IRepository<Product, int> _productRepository;
    private readonly IRepository<Shipper, int> _shipperRepository;

    public Seeder(IRepository<Employee, int> employeeRepository, IRepository<Region, int> regionRepository, IRepository<Territory, string> territoryRepository, IRepository<Customer, string> customerRepository, IRepository<Supplier, int> supplierRepository, IRepository<Category, int> categoryRepository, IRepository<Product, int> productRepository, IRepository<Shipper, int> shipperRepository)
    {
      _employeeRepository = employeeRepository;
      _regionRepository = regionRepository;
      _territoryRepository = territoryRepository;
      _customerRepository = customerRepository;
      _supplierRepository = supplierRepository;
      _categoryRepository = categoryRepository;
      _productRepository = productRepository;
      this._shipperRepository = shipperRepository;
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

      // Seed Categories
      if (await _categoryRepository.GetCountAsync() <= 0)
      {
        CategoryData.AddCategories();
        foreach (var category in CategoryData.Categories.Values)
        {
          await _categoryRepository.InsertAsync(category);
        }
      }

      // Seed Products
      if (await _productRepository.GetCountAsync() <= 0)
      {
        ProductData.AddProducts();
        foreach (var product in ProductData.Products.Values)
        {
          await _productRepository.InsertAsync(product);
        }
      }

      // Seed Shippers
      if (await _shipperRepository.GetCountAsync() <= 0)
      {
        ShipperData.AddShippers();
        foreach (var shipper in ShipperData.Shippers.Values)
        {
          await _shipperRepository.InsertAsync(shipper);
        }
      }

    }
  }
}