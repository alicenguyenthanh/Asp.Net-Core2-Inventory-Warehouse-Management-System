using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using netcore.Models;
using netcore.Models.Invent;

namespace netcore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<netcore.Models.ApplicationUser> ApplicationUser { get; set; }

        public DbSet<netcore.Models.Invent.Branch> Branch { get; set; }

        public DbSet<netcore.Models.Invent.Warehouse> Warehouse { get; set; }

        public DbSet<netcore.Models.Invent.Product> Product { get; set; }

        public DbSet<netcore.Models.Invent.Vendor> Vendor { get; set; }

        public DbSet<netcore.Models.Invent.VendorLine> VendorLine { get; set; }

        public DbSet<netcore.Models.Invent.PurchaseOrder> PurchaseOrder { get; set; }

        public DbSet<netcore.Models.Invent.PurchaseOrderLine> PurchaseOrderLine { get; set; }

        public DbSet<netcore.Models.Invent.Customer> Customer { get; set; }

        public DbSet<netcore.Models.Invent.CustomerLine> CustomerLine { get; set; }

        public DbSet<netcore.Models.Invent.SalesOrder> SalesOrder { get; set; }

        public DbSet<netcore.Models.Invent.SalesOrderLine> SalesOrderLine { get; set; }

        public DbSet<netcore.Models.Invent.Shipment> Shipment { get; set; }

        public DbSet<netcore.Models.Invent.ShipmentLine> ShipmentLine { get; set; }

        public DbSet<netcore.Models.Invent.Receiving> Receiving { get; set; }

        public DbSet<netcore.Models.Invent.ReceivingLine> ReceivingLine { get; set; }

        public DbSet<netcore.Models.Invent.TransferOrder> TransferOrder { get; set; }

        public DbSet<netcore.Models.Invent.TransferOrderLine> TransferOrderLine { get; set; }

        public DbSet<netcore.Models.Invent.TransferOut> TransferOut { get; set; }

        public DbSet<netcore.Models.Invent.TransferOutLine> TransferOutLine { get; set; }

        public DbSet<netcore.Models.Invent.TransferIn> TransferIn { get; set; }

        public DbSet<netcore.Models.Invent.TransferInLine> TransferInLine { get; set; }
        
    }
}
