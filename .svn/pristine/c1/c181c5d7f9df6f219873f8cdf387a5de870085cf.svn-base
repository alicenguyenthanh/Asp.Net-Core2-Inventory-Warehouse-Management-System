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
        [Display(Name = "Transfer Id")]
        public string transferOrderId { get; set; }

        [StringLength(20)]
        [Required]
        [Display(Name = "Transfer Number")]
        public string transferOrderNumber { get; set; }

        [Required]
        [Display(Name = "Transfer Date")]
        public DateTime transferOrderDate { get; set; }

        [StringLength(100)]
        [Required]
        [Display(Name = "Description")]
        public string description { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "PIC Name")]
        public string picName { get; set; }

        [StringLength(38)]
        [Display(Name = "From Branch")]
        public string branchIdFrom { get; set; }

        [Display(Name = "From Branch")]
        public Branch branchFrom { get; set; }

        [StringLength(38)]
        [Display(Name = "From Warehouse")]
        public string warehouseIdFrom { get; set; }

        [Display(Name = "From Warehouse")]
        public Warehouse warehouseFrom { get; set; }

        [StringLength(38)]
        [Display(Name = "To Branch")]
        public string branchIdTo { get; set; }

        [Display(Name = "To Branch")]
        public Branch branchTo { get; set; }

        [StringLength(38)]
        [Display(Name = "To Warehouse")]
        public string warehouseIdTo { get; set; }

        [Display(Name = "To Warehouse")]
        public Warehouse warehouseTo { get; set; }

        [Display(Name = "Transfer Order Status")]
        public TransferOrderStatus transferOrderStatus { get; set; }

        [Display(Name = "Is Issued")]
        public bool isIssued { get; set; }

        [Display(Name = "Is Received")]
        public bool isReceived { get; set; }

        [Display(Name = "Transfer Order Lines")]
        public List<TransferOrderLine> transferOrderLine { get; set; } = new List<TransferOrderLine>();
    }
}
