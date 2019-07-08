using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netcore.Models.Invent
{
    public class SalesOrder : INetcoreMasterChild
    {
        public SalesOrder()
        {
            this.createdAt = DateTime.UtcNow;
            this.salesOrderNumber = DateTime.UtcNow.Date.ToString("yyyyMMdd") + Guid.NewGuid().ToString().Substring(0, 5).ToUpper() + "#SO";
            this.soDate = DateTime.UtcNow.Date;
            this.deliveryDate = this.soDate.AddDays(5);
            this.salesOrderStatus = SalesOrderStatus.Draft;
            this.totalDiscountAmount = 0m;
            this.totalOrderAmount = 0m;
        }

        [StringLength(38)]
        [Display(Name = "Sales Order Id")]
        public string salesOrderId { get; set; }

        [StringLength(20)]
        [Required]
        [Display(Name = "SO Number")]
        public string salesOrderNumber { get; set; }

        [Display(Name = "Terms of Payment (TOP)")]
        public TOP top { get; set; }

        [Display(Name = "SO Date")]
        public DateTime soDate { get; set; }

        [Display(Name = "Delivery Date")]
        public DateTime deliveryDate { get; set; }

        [StringLength(50)]
        [Display(Name = "Delivery Address")]
        public string deliveryAddress { get; set; }

        [StringLength(30)]
        [Display(Name = "Reference Number (Internal)")]
        public string referenceNumberInternal { get; set; }

        [StringLength(30)]
        [Display(Name = "Reference Number (External)")]
        public string referenceNumberExternal { get; set; }

        [StringLength(100)]
        [Display(Name = "Description")]
        public string description { get; set; }

        [StringLength(38)]
        [Required]
        [Display(Name = "Branch Id")]
        public string branchId { get; set; }

        [Display(Name = "Branch")]
        public Branch branch { get; set; }

        [StringLength(38)]
        [Required]
        [Display(Name = "Customer Id")]
        public string customerId { get; set; }

        [Display(Name = "Customer")]
        public Customer customer { get; set; }

        [StringLength(30)]
        [Required]
        [Display(Name = "PIC Internal")]
        public string picInternal { get; set; }

        [StringLength(30)]
        [Required]
        [Display(Name = "PIC Customer")]
        public string picCustomer { get; set; }

        [Display(Name = "SO Status")]
        public SalesOrderStatus salesOrderStatus { get; set; }

        [Display(Name = "Total Discount")]
        public decimal totalDiscountAmount { get; set; }

        [Display(Name = "Total Order")]
        public decimal totalOrderAmount { get; set; }

        [Display(Name = "Sales Shipment Number")]
        public string salesShipmentNumber { get; set; }

        [Display(Name = "Sales Order Lines")]
        public List<SalesOrderLine> salesOrderLine { get; set; } = new List<SalesOrderLine>();
    }
}
