using AbpNorthwindTraders.Domain;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using static AbpNorthwindTraders.AbpNorthwindTradersSharedDomainConstants;

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
                b.Property(e => e.Id).HasColumnName("EmployeeID");
                b.Property(e => e.Address).HasMaxLength(EmployeeConsts.MaxLengthAddress);
                b.Property(e => e.BirthDate).HasColumnType("datetime");
                b.Property(e => e.City).HasMaxLength(EmployeeConsts.MaxLengthCity);
                b.Property(e => e.Country).HasMaxLength(EmployeeConsts.MaxLengthCountry);
                b.Property(e => e.Extension).HasMaxLength(EmployeeConsts.MaxLengthExtension);
                b.Property(e => e.FirstName).IsRequired().HasMaxLength(EmployeeConsts.MaxLengthFirstName);
                b.Property(e => e.HireDate).HasColumnType("datetime");
                b.Property(e => e.HomePhone).HasMaxLength(EmployeeConsts.MaxLengthHomePhone);
                b.Property(e => e.LastName).IsRequired().HasMaxLength(EmployeeConsts.MaxLengthLastName);
                b.Property(e => e.Notes).HasColumnType("ntext");
                b.Property(e => e.Photo).HasColumnType("image");
                b.Property(e => e.PhotoPath).HasMaxLength(EmployeeConsts.MaxLengthPhotoPath);
                b.Property(e => e.PostalCode).HasMaxLength(EmployeeConsts.MaxLengthPostalCode);
                b.Property(e => e.Region).HasMaxLength(EmployeeConsts.MaxLengthRegion);
                b.Property(e => e.Title).HasMaxLength(EmployeeConsts.MaxLengthTitle);
                b.HasOne(d => d.Manager).WithMany(p => p.DirectReports).HasForeignKey(d => d.ReportsTo)
                    .HasConstraintName("FK_Employees_Employees");
            });


            builder.Entity<Region>(b =>
            {
                b.ToTable(AbpNorthwindTradersConsts.DbTablePrefix + "Regions", AbpNorthwindTradersConsts.DbSchema);
                b.ConfigureByConvention();
                b.HasKey(e => e.Id).IsClustered(false);
                b.Property(e => e.Id).HasColumnName("RegionID").ValueGeneratedNever();
                b.Property(e => e.RegionDescription).IsRequired().HasMaxLength(RegionConsts.MaxLengthRegionDescription);
            });

            builder.Entity<Territory>(b =>
            {
                b.ToTable(AbpNorthwindTradersConsts.DbTablePrefix + "Territories", AbpNorthwindTradersConsts.DbSchema);
                b.ConfigureByConvention();
                b.HasKey(e => e.Id).IsClustered(false);
                b.Property(e => e.Id).HasColumnName("TerritoryID").HasMaxLength(TerritoryConsts.MaxLengthTerritoryId).ValueGeneratedNever();
                b.Property(e => e.RegionId).HasColumnName("RegionID");
                b.Property(e => e.TerritoryDescription).IsRequired().HasMaxLength(TerritoryConsts.MaxLengthTerritoryDescription);
                b.HasOne(d => d.Region)
                    .WithMany(p => p.Territories)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Territories_Region");
            });

            builder.Entity<EmployeeTerritory>(b =>
            {
                b.ToTable(AbpNorthwindTradersConsts.DbTablePrefix + "EmployeeTerritories", AbpNorthwindTradersConsts.DbSchema);
                b.ConfigureByConvention();
                b.HasKey(e => new {e.EmployeeId, e.TerritoryId}).IsClustered(false);
                b.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
                b.Property(e => e.TerritoryId).HasColumnName("TerritoryID").HasMaxLength(EmployeeTerritoryConsts.MaxLengthTerritoryId);
                b.HasOne(d => d.Employee).WithMany(p => p.EmployeeTerritories).HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_EmployeeTerritories_Employees");
                b.HasOne(d => d.Territory).WithMany(p => p.EmployeeTerritories).HasForeignKey(d => d.TerritoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_EmployeeTerritories_Territories");
            });
        }
    }
}
