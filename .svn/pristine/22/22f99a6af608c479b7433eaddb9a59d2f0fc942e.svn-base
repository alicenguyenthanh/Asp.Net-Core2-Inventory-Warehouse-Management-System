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
        [Display(Name = "Sales Order Id")]
        public string salesOrderId { get; set; }

        [Display(Name = "Sales Order")]
        public SalesOrder salesOrder { get; set; }

        [StringLength(20)]
        [Required]
        [Display(Name = "DO Number")]
        public string shipmentNumber { get; set; }

        [Required]
        [Display(Name = "DO Date")]
        public DateTime shipmentDate { get; set; }

        [StringLength(38)]
        [Display(Name = "Customer Id")]
        public string customerId { get; set; }

        [Display(Name = "Customer")]
        public Customer customer { get; set; }

        [StringLength(50)]
        [Display(Name = "Customer PO Number")]
        public string customerPO { get; set; }

        [StringLength(50)]
        [Display(Name = "Invoice Number")]
        public string invoice { get; set; }

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

        [Display(Name = "Expedition Type")]
        public ExpeditionType expeditionType { get; set; }

        [Display(Name = "Expedition Mode")]
        public ExpeditionMode expeditionMode { get; set; }

        [Display(Name = "Shipment Lines")]
        public List<ShipmentLine> shipmentLine { get; set; } = new List<ShipmentLine>();
    }
}
