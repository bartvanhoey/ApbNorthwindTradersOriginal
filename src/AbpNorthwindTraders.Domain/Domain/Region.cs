using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace AbpNorthwindTraders.Domain

{
    public class Region : FullAuditedEntity<int>, IMultiTenant
    {
        public Region()
        {
            Territories = new HashSet<Territory>();
        }

        public new int Id { get; set; }
        public string RegionDescription { get; set; }

        public ICollection<Territory> Territories { get; private set; }
        public Guid? TenantId { get; }

   

        public Region(
            int id, 
            string regionDescription, 
            ICollection<Territory> territories, 
            Guid? tenantId
        ) : base(id)
        {
            Id = id;
            RegionDescription = regionDescription;
            Territories = territories;
            TenantId = tenantId;
        }
    }
}
