using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netcore.Models.Invent
{
    public class PurchaseOrderLine : INetcoreBasic
    {
        public PurchaseOrderLine()
        {
            this.createdAt = DateTime.UtcNow;
            this.discountAmount = 0m;
            this.totalAmount = 0m;
        }

        [StringLength(38)]
        [Display(Name = "Purchase Order Line Id")]
        public string purchaseOrderLineId { get; set; }

        [StringLength(38)]
        [Display(Name = "Purchase Order Id")]
        public string purchaseOrderId { get; set; }

        [Display(Name = "Purchase Order")]
        public PurchaseOrder purchaseOrder { get; set; }

        [StringLength(38)]
        [Display(Name = "Product Id")]
        public string productId { get; set; }

        [Display(Name = "Product")]
        public Product product { get; set; }

        [Display(Name = "Qty")]
        public float qty { get; set; }

        [Display(Name = "Item Price")]
        public decimal price { get; set; }

        [Display(Name = "Discount Amount")]
        public decimal discountAmount { get; set; }

        [Display(Name = "Total Amount")]
        public decimal totalAmount { get; set; }
    }
}
