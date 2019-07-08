using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netcore.Models.Invent
{
    public class Product: INetcoreBasic
    {
        public Product()
        {
            this.createdAt = DateTime.UtcNow;
        }

        [StringLength(38)]
        [Display(Name = "Hàng hóa Id")]
        public string productId { get; set; }

        [StringLength(50)]
        [Display(Name = "Mã hàng hóa")]
        [Required]
        public string productCode { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên hàng hóa")]
        [Required]
        public string productName { get; set; }

        [StringLength(50)]
        [Display(Name = "Thông tin hàng hóa")]
        public string description { get; set; }

        [StringLength(50)]
        [Display(Name = "Barcode")]
        public string barcode { get; set; }

        [StringLength(50)]
        [Display(Name = "Serial Number")]
        public string serialNumber { get; set; }

        
        [Display(Name = "Loại hàng hóa")]
        public ProductType productType { get; set; }

       
        [Display(Name = "Đơn vị tính")]
        public UOM uom { get; set; }
    }
}
