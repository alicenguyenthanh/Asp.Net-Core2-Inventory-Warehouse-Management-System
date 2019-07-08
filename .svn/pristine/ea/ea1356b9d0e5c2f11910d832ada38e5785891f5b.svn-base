using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netcore.Models.Invent
{
    public class TransferOrderLine : INetcoreBasic
    {
        public TransferOrderLine()
        {
            this.createdAt = DateTime.UtcNow;
        }

        [StringLength(38)]
        [Display(Name = "Transfer Order Line Id")]
        public string transferOrderLineId { get; set; }

        [StringLength(38)]
        [Display(Name = "Transfer Order Id")]
        public string transferOrderId { get; set; }

        [Display(Name = "Transfer Order")]
        public TransferOrder transferOrder { get; set; }

        [StringLength(38)]
        [Display(Name = "Product Id")]
        public string productId { get; set; }

        [Display(Name = "Product")]
        public Product product { get; set; }

        [Display(Name = "Qty")]
        public float qty { get; set; }
    }
}
