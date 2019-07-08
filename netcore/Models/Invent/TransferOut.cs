using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netcore.Models.Invent
{
    public class TransferOut : INetcoreMasterChild
    {
        public TransferOut()
        {
            this.createdAt = DateTime.UtcNow;
            this.transferOutNumber = DateTime.UtcNow.Date.ToString("yyyyMMdd") + Guid.NewGuid().ToString().Substring(0, 5).ToUpper() + "#OUT";
            this.transferOutDate = DateTime.UtcNow;
        }

        [StringLength(38)]
        [Display(Name = "Xuất điều chuyển Id")]
        public string transferOutId { get; set; }

        [StringLength(38)]
        [Required]
        [Display(Name = "Lệnh xuất điều chuyển Id")]
        public string transferOrderId { get; set; }

        [Display(Name = "Lệnh xuất điều chuyển")]
        public TransferOrder transferOrder { get; set; }

        [StringLength(20)]
        [Required]
        [Display(Name = "Số hàng hóa (TO)")]
        public string transferOutNumber { get; set; }

        [Required]
        [Display(Name = "Ngày hàng hóa (TO)")]
        public DateTime transferOutDate { get; set; }

        [StringLength(100)]
        [Required]
        [Display(Name = "Thông tin mô tả")]
        public string description { get; set; }
        

        [StringLength(38)]
        [Display(Name = "Từ đơn vị công ty Id")]
        public string branchIdFrom { get; set; }

        [Display(Name = "Từ đơn vị công ty")]
        public Branch branchFrom { get; set; }

        [StringLength(38)]
        [Display(Name = "Từ kho Id")]
        public string warehouseIdFrom { get; set; }

        [Display(Name = "Từ kho")]
        public Warehouse warehouseFrom { get; set; }

        [StringLength(38)]
        [Display(Name = "Đến đơn vị công ty Id")]
        public string branchIdTo { get; set; }

        [Display(Name = "Đến đơn vị công ty")]
        public Branch branchTo { get; set; }

        [StringLength(38)]
        [Display(Name = "Đến kho Id")]
        public string warehouseIdTo { get; set; }

        [Display(Name = "Đến kho")]
        public Warehouse warehouseTo { get; set; }

        [Display(Name = "Transfer Out Lines")]
        public List<TransferOutLine> transferOutLine { get; set; } = new List<TransferOutLine>();
    }
}
