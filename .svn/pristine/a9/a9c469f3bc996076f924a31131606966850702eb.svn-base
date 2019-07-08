using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netcore.Models.Invent
{
    public class Receiving : INetcoreMasterChild
    {
        public Receiving()
        {
            this.createdAt = DateTime.UtcNow;
            this.receivingNumber = DateTime.UtcNow.Date.ToString("yyyyMMdd") + Guid.NewGuid().ToString().Substring(0, 5).ToUpper() + "#GSRN";
            this.receivingDate = DateTime.UtcNow;
        }

        [StringLength(38)]
        [Display(Name = "Receiving Id")]
        public string receivingId { get; set; }

        [StringLength(38)]
        [Required]
        [Display(Name = "Purchase Order Id")]
        public string purchaseOrderId { get; set; }

        [Display(Name = "Purchase Order")]
        public PurchaseOrder purchaseOrder { get; set; }

        [StringLength(20)]
        [Required]
        [Display(Name = "GSRN Number")]
        public string receivingNumber { get; set; }
        
        [Required]
        [Display(Name = "GSRN Date")]
        public DateTime receivingDate { get; set; }

        [StringLength(38)]
        [Display(Name = "Vendor Id")]
        public string vendorId { get; set; }

        [Display(Name = "Vendor")]
        public Vendor vendor { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "Vendor DO Number")]
        public string vendorDO { get; set; }

        [StringLength(50)]
        [Display(Name = "Vendor Invoice Number")]
        public string vendorInvoice { get; set; }

        [StringLength(38)]
        [Display(Name = "Branch Id")]
        public string branchId { get; set; }

        [Display(Name = "Branch")]
        public Branch branch { get; set; }

        [StringLength(38)]
        [Required]
        [Display(Name = "Warehouse Id")]
        public string warehouseId { get; set; }

        [Display(Name = "Warehouse")]
        public Warehouse warehouse { get; set; }

        [Display(Name = "Receiving Lines")]
        public List<ReceivingLine> receivingLine { get; set; } = new List<ReceivingLine>();
    }
}
