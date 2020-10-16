using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace AbpNorthwindTraders.Domain
{
     public class Shipper : FullAuditedEntity<int>, IMultiTenant
    {
        public Shipper()
        {
            // Orders = new HashSet<Order>();
        }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        // public ICollection<Order> Orders { get; private set; }
        public System.Guid? TenantId { get; }

 
        public Shipper(
            int id, 
            string companyName, 
            string phone, 
            System.Guid? tenantId
        ) : base(id)
        {
            CompanyName = companyName;
            Phone = phone;
            TenantId = tenantId;
        }
    }
}
