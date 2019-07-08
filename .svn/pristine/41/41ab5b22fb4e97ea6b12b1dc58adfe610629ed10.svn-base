using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netcore.Models.Invent
{
    public class TransferInLine : INetcoreBasic
    {
        public TransferInLine()
        {
            this.createdAt = DateTime.UtcNow;
        }

        [StringLength(38)]
        [Display(Name = "Transfer In Line Id")]
        public string transferInLineId { get; set; }

        [StringLength(38)]
        [Display(Name = "Goods Receive Id")]
        public string transferInId { get; set; }

        [Display(Name = "Goods Receive")]
        public TransferIn transferIn { get; set; }

        [StringLength(38)]
        [Display(Name = "Product Id")]
        public string productId { get; set; }

        [Display(Name = "Product")]
        public Product product { get; set; }

        [Display(Name = "Qty")]
        public float qty { get; set; }

        [Display(Name = "Qty Inventory")]
        public float qtyInventory { get; set; }
    }
}
