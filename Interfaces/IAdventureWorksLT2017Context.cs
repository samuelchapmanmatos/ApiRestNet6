using ApiRestNet6.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiRestNet6.Interfaces
{
    public interface IAdventureWorksLT2017Context
    {
        DbSet<Address> Addresses { get; set; }
        DbSet<BuildVersion> BuildVersions { get; set; }
        DbSet<CustomerAddress> CustomerAddresses { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<ErrorLog> ErrorLogs { get; set; }
        DbSet<ProductCategory> ProductCategories { get; set; }
        DbSet<ProductDescription> ProductDescriptions { get; set; }
        DbSet<ProductModelProductDescription> ProductModelProductDescriptions { get; set; }
        DbSet<ProductModel> ProductModels { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
        DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }
        DbSet<VGetAllCategory> VGetAllCategories { get; set; }
        DbSet<VProductAndDescription> VProductAndDescriptions { get; set; }
        DbSet<VProductModelCatalogDescription> VProductModelCatalogDescriptions { get; set; }
    }
}
