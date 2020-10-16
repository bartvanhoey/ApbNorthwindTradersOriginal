using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace AbpNorthwindTraders.Domain
{
  public class Product : FullAuditedEntity<int>, IMultiTenant
  {
    public Product()
    {
      //   OrderDetails = new HashSet<OrderDetail>();
    }
    public string ProductName { get; set; }
    public int? SupplierId { get; set; }
    public int? CategoryId { get; set; }
    public string QuantityPerUnit { get; set; }
    public decimal? UnitPrice { get; set; }
    public short? UnitsInStock { get; set; }
    public short? UnitsOnOrder { get; set; }
    public short? ReorderLevel { get; set; }
    public bool Discontinued { get; set; }

    public Category Category { get; set; }
    public Supplier Supplier { get; set; }
    // public ICollection<OrderDetail> OrderDetails { get; private set; }
    public Guid? TenantId { get; }



    public Product(
        int id,
        string productName,
        int? supplierId,
        int? categoryId,
        string quantityPerUnit,
        decimal? unitPrice,
        short? unitsInStock,
        short? unitsOnOrder,
        short? reorderLevel,
        bool discontinued,
        Category category,
        Supplier supplier,
        Guid? tenantId
    ) : base(id)
    {
      ProductName = productName;
      SupplierId = supplierId;
      CategoryId = categoryId;
      QuantityPerUnit = quantityPerUnit;
      UnitPrice = unitPrice;
      UnitsInStock = unitsInStock;
      UnitsOnOrder = unitsOnOrder;
      ReorderLevel = reorderLevel;
      Discontinued = discontinued;
      Category = category;
      Supplier = supplier;
      TenantId = tenantId;
    }
  }
}
