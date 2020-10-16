using System.Collections.Generic;

namespace AbpNorthwindTraders.Domain.DataSeeder.Data
{
  public static class ShipperData
  {
    public static readonly Dictionary<int, Shipper> Shippers = new Dictionary<int, Shipper>();

    public static void AddShippers()
    {
      Shippers.Add(1, new Shipper { CompanyName = "Speedy Express", Phone = "(503) 555-9831" });
      Shippers.Add(2, new Shipper { CompanyName = "United Package", Phone = "(503) 555-3199" });
      Shippers.Add(3, new Shipper { CompanyName = "Federal Shipping", Phone = "(503) 555-9931" });
    }
  }
}