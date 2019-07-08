using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netcore.Models.Invent
{
    public class Shipment : INetcoreMasterChild
    {
        public Shipment()
        {
            this.createdAt = DateTime.UtcNow;
            this.shipmentNumber = DateTime.UtcNow.Date.ToString("yyyyMMdd") + Guid.NewGuid().ToString().Substring(0, 5).ToUpper() + "#DO";
            this.shipmentDate = DateTime.UtcNow;
            this.expeditionType = ExpeditionType.Internal;
            this.expeditionMode = ExpeditionMode.Land;
        }

        [StringLength(38)]
        [Display(Name = "Shipment Id")]
        public string shipmentId { get; set; }

        [StringLength(38)]
        [Required]
        [Display(Name = "Chọn số SO Id")]
        public string salesOrderId { get; set; }

        [Display(Name = "Số SO")]
        public SalesOrder salesOrder { get; set; }

        [StringLength(20)]
        [Required]
        [Display(Name = "Số DO")]
        public string shipmentNumber { get; set; }

        [Required]
        [Display(Name = "Ngày DO")]
        public DateTime shipmentDate { get; set; }

        [StringLength(38)]
        [Display(Name = "Khách hàng Id")]
        public string customerId { get; set; }

        [Display(Name = "Khách hàng")]
        public Customer customer { get; set; }

        [StringLength(50)]
        [Display(Name = "Số PO khách hàng")]
        public string customerPO { get; set; }

        [StringLength(50)]
        [Display(Name = "Số hóa đơn")]
        public string invoice { get; set; }

        [StringLength(38)]
        [Display(Name = "Đơn vị công ty Id")]
        public string branchId { get; set; }

        [Display(Name = "Đơn vị công ty")]
        public Branch branch { get; set; }

        [StringLength(38)]
        [Required]
        [Display(Name = "Chọn kho hàng Id")]
        public string warehouseId { get; set; }

        [Display(Name = "Kho hàng")]
        public Warehouse warehouse { get; set; }

        [Display(Name = "Loại xuất chuyển")]
        public ExpeditionType expeditionType { get; set; }

        [Display(Name = "Loại vận chuyển")]
        public ExpeditionMode expeditionMode { get; set; }

        [Display(Name = "Shipment Lines")]
        public List<ShipmentLine> shipmentLine { get; set; } = new List<ShipmentLine>();
    }
}
