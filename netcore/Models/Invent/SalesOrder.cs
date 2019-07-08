using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netcore.Models.Invent
{
    public class SalesOrder : INetcoreMasterChild
    {
        public SalesOrder()
        {
            this.createdAt = DateTime.UtcNow;
            this.salesOrderNumber = DateTime.UtcNow.Date.ToString("yyyyMMdd") + Guid.NewGuid().ToString().Substring(0, 5).ToUpper() + "#SO";
            this.soDate = DateTime.UtcNow.Date;
            this.deliveryDate = this.soDate.AddDays(5);
            this.salesOrderStatus = SalesOrderStatus.Draft;
            this.totalDiscountAmount = 0m;
            this.totalOrderAmount = 0m;
        }

        [StringLength(38)]
        [Display(Name = "Sales Order Id")]
        public string salesOrderId { get; set; }

        [StringLength(20)]
        [Required]
        [Display(Name = "Số SO")]
        public string salesOrderNumber { get; set; }

        [Display(Name = "Điều khoản thanh toán")]
        public TOP top { get; set; }

        [Display(Name = "Ngày SO")]
        public DateTime soDate { get; set; }

        [Display(Name = "Ngày giao hàng")]
        public DateTime deliveryDate { get; set; }

        [StringLength(50)]
        [Display(Name = "Địa chỉ nơi giao hàng")]
        public string deliveryAddress { get; set; }

        [StringLength(30)]
        [Display(Name = "Số chứng từ tham chiếu (Nội bộ)")]
        public string referenceNumberInternal { get; set; }

        [StringLength(30)]
        [Display(Name = "Số chứng từ tham chiếu (Khách hàng)")]
        public string referenceNumberExternal { get; set; }

        [StringLength(100)]
        [Display(Name = "Thông tin mô tả")]
        public string description { get; set; }

        [StringLength(38)]
        [Required]
        [Display(Name = "Đơn vị công ty Id")]
        public string branchId { get; set; }

        [Display(Name = "Đơn vị công ty")]
        public Branch branch { get; set; }

        [StringLength(38)]
        [Required]
        [Display(Name = "Khách hàng Id")]
        public string customerId { get; set; }

        [Display(Name = "Khách hàng")]
        public Customer customer { get; set; }

        [StringLength(30)]
        [Required]
        [Display(Name = "Người lập đề nghị xuất hàng (Nội bộ)")]
        public string picInternal { get; set; }

        [StringLength(30)]
        [Required]
        [Display(Name = "Người nhận hàng (Khách hàng)")]
        public string picCustomer { get; set; }

        [Display(Name = "Trạng thái SO")]
        public SalesOrderStatus salesOrderStatus { get; set; }

        [Display(Name = "Total Discount")]
        public decimal totalDiscountAmount { get; set; }

        [Display(Name = "Tổng tiền đơn hàng")]
        public decimal totalOrderAmount { get; set; }

        [Display(Name = "Số lô hàng xuất")]
        public string salesShipmentNumber { get; set; }

        [Display(Name = "Sales Order Lines")]
        public List<SalesOrderLine> salesOrderLine { get; set; } = new List<SalesOrderLine>();
    }
}
