using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netcore.Models.Invent
{
    public class ShipmentLine : INetcoreBasic
    {
        public ShipmentLine()
        {
            this.createdAt = DateTime.UtcNow;
        }

        [StringLength(38)]
        [Display(Name = "Shipment Line Id")]
        public string shipmentLineId { get; set; }

        [StringLength(38)]
        [Display(Name = "Shipment Id")]
        public string shipmentId { get; set; }

        [Display(Name = "Shipment")]
        public Shipment shipment { get; set; }

        [StringLength(38)]
        [Display(Name = "Đơn vị công ty Id")]
        public string branchId { get; set; }

        [Display(Name = "Đơn vị công ty")]
        public Branch branch { get; set; }

        [StringLength(38)]
        [Display(Name = "Kho hàng Id")]
        public string warehouseId { get; set; }

        [Display(Name = "Kho hàng")]
        public Warehouse warehouse { get; set; }

        [StringLength(38)]
        [Display(Name = "Hàng hóa Id")]
        public string productId { get; set; }

        [Display(Name = "Hàng hóa")]
        public Product product { get; set; }

        [Display(Name = "Số lượng")]
        public float qty { get; set; }

        [Display(Name = "Số lượng xuất")]
        public float qtyShipment { get; set; }

        [Display(Name = "Số lượng tồn")]
        public float qtyInventory { get; set; }
    }
}
