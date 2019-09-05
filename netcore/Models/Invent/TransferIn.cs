using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netcore.Models.Invent
{
    public class TransferIn : INetcoreMasterChild
    {
        public TransferIn()
        {
            this.createdAt = DateTime.UtcNow;
            this.transferInNumber = DateTime.UtcNow.Date.ToString("yyyyMMdd") + Guid.NewGuid().ToString().Substring(0, 5).ToUpper() + "#IN";
            this.transferInDate = DateTime.UtcNow;
        }

        [StringLength(38)]
        [Display(Name = "Transfer In Id")]
        public string transferInId { get; set; }

        [StringLength(38)]
        [Required]
        [Display(Name = "Transfer Order Id")]
        public string transferOrderId { get; set; }

        [Display(Name = "Lệnh xuất điều chuyển")]
        public TransferOrder transferOrder { get; set; }

        [StringLength(20)]
        [Required]
        [Display(Name = "Số hàng hóa (TI)")]
        public string transferInNumber { get; set; }

        [Required]
        [Display(Name = "Ngày hàng hóa (TI)")]
        public DateTime transferInDate { get; set; }

        [StringLength(100)]
        [Required]
        [Display(Name = "Thông tin mô tả")]
        public string description { get; set; }


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

        [Display(Name = "Transfer In Lines")]
        public List<TransferInLine> transferInLine { get; set; } = new List<TransferInLine>();
    }
}
