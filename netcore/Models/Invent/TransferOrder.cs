using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netcore.Models.Invent
{
    public class TransferOrder : INetcoreMasterChild
    {
        public TransferOrder()
        {
            this.createdAt = DateTime.UtcNow;
            this.transferOrderNumber = DateTime.UtcNow.Date.ToString("yyyyMMdd") + Guid.NewGuid().ToString().Substring(0, 5).ToUpper() + "#TO";
            this.transferOrderDate = DateTime.UtcNow;
            this.transferOrderStatus = TransferOrderStatus.Draft;
            this.isIssued = false;
            this.isReceived = false;
        }

        [StringLength(38)]
        [Display(Name = "Số TO Id")]
        public string transferOrderId { get; set; }

        [StringLength(20)]
        [Required]
        [Display(Name = "Số TO")]
        public string transferOrderNumber { get; set; }

        [Required]
        [Display(Name = "Ngày TO")]
        public DateTime transferOrderDate { get; set; }

        [StringLength(100)]
        [Required]
        [Display(Name = "Thông tin mô tả")]
        public string description { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "Người thực hiện TO")]
        public string picName { get; set; }

        [StringLength(38)]
        [Display(Name = "Từ Đơn vị công ty Id")]
        public string branchIdFrom { get; set; }

        [Display(Name = "Từ Đơn vị công ty")]
        public Branch branchFrom { get; set; }

        [StringLength(38)]
        [Display(Name = "Từ kho Id")]
        public string warehouseIdFrom { get; set; }

        [Display(Name = "Từ kho")]
        public Warehouse warehouseFrom { get; set; }

        [StringLength(38)]
        [Display(Name = "Đến Đơn vị công ty Id")]
        public string branchIdTo { get; set; }

        [Display(Name = "Đến Đơn vị công ty")]
        public Branch branchTo { get; set; }

        [StringLength(38)]
        [Display(Name = "Đến kho Id")]
        public string warehouseIdTo { get; set; }

        [Display(Name = "Đến kho")]
        public Warehouse warehouseTo { get; set; }

        [Display(Name = "Trạng thái TO")]
        public TransferOrderStatus transferOrderStatus { get; set; }

        [Display(Name = "Is Issued")]
        public bool isIssued { get; set; }

        [Display(Name = "Is Received")]
        public bool isReceived { get; set; }

        [Display(Name = "Transfer Order Lines")]
        public List<TransferOrderLine> transferOrderLine { get; set; } = new List<TransferOrderLine>();
    }
}
