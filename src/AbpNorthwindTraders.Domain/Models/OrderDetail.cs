using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace AbpNorthwindTraders.Domain.Models
{
    public class OrderDetail: FullAuditedEntity, IMultiTenant
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
        public override object[] GetKeys()
        {
            return new object[] { OrderId, ProductId};
        }

        public Guid? TenantId { get; }
    }
}