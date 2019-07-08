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
        [Display(Name = "Phiếu đề nghị nhập hàng (Id)")]
        public string purchaseOrderId { get; set; }

        [Display(Name = "Phiếu đề nghị nhập (PO)")]
        public PurchaseOrder purchaseOrder { get; set; }

        [StringLength(20)]
        [Required]
        [Display(Name = "Số phiếu nhập hàng")]
        public string receivingNumber { get; set; }
        
        [Required]
        [Display(Name = "Ngày nhập hàng")]
        public DateTime receivingDate { get; set; }

        [StringLength(38)]
        [Display(Name = "vendorId")]
        public string vendorId { get; set; }

        [Display(Name = "Nhà cung cấp")]
        public Vendor vendor { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "Số yêu cầu giao hàng(DO)")]
        public string vendorDO { get; set; }

        [StringLength(50)]
        [Display(Name = "Số hóa đơn giao hàng")]
        public string vendorInvoice { get; set; }

        [StringLength(38)]
        [Display(Name = "Branch Id")]
        public string branchId { get; set; }

        [Display(Name = "Đơn vị công ty")]
        public Branch branch { get; set; }

        [StringLength(38)]
        [Required]
        [Display(Name = "Kho hàng Id")]
        public string warehouseId { get; set; }

        [Display(Name = "Kho hàng")]
        public Warehouse warehouse { get; set; }

        [Display(Name = "Receiving Lines")]
        public List<ReceivingLine> receivingLine { get; set; } = new List<ReceivingLine>();
    }
}
