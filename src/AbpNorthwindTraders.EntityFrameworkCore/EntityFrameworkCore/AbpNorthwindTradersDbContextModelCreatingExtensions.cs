using AbpNorthwindTraders.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace AbpNorthwindTraders.EntityFrameworkCore
{
    public static class AbpNorthwindTradersDbContextModelCreatingExtensions
    {
        public static void ConfigureAbpNorthwindTraders(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(AbpNorthwindTradersConsts.DbTablePrefix + "YourEntities", AbpNorthwindTradersConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});


            builder.Entity<Employee>(b =>
            {
                b.ToTable(AbpNorthwindTradersConsts.DbTablePrefix + "Employees", AbpNorthwindTradersConsts.DbSchema);
                b.ConfigureByConvention(); 
                

                /* Configure more properties here */
            });
        }
    }
}
