using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netcore.Models.Invent
{
    public class SalesOrderLine : INetcoreBasic
    {
        public SalesOrderLine()
        {
            this.createdAt = DateTime.UtcNow;
            this.discountAmount = 0m;
            this.totalAmount = 0m;
        }

        [StringLength(38)]
        [Display(Name = "Sales Order Line Id")]
        public string salesOrderLineId { get; set; }

        [StringLength(38)]
        [Display(Name = "Sales Order Id")]
        public string salesOrderId { get; set; }

        [Display(Name = "Sales Order")]
        public SalesOrder salesOrder { get; set; }

        [StringLength(38)]
        [Display(Name = "Tên hàng hóa Id")]
        public string productId { get; set; }

        [Display(Name = "Tên hàng hóa")]
        public Product product { get; set; }

        [Display(Name = "Số lượng")]
        public float qty { get; set; }

        [Display(Name = "Giá")]
        public decimal price { get; set; }

        [Display(Name = "Số tiền giảm giá")]
        public decimal discountAmount { get; set; }

        [Display(Name = "Total Amount")]
        public decimal totalAmount { get; set; }
    }
}
