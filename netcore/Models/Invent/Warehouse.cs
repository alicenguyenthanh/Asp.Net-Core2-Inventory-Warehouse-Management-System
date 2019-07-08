using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netcore.Models.Invent
{
    public class Warehouse: INetcoreBasic, IBaseAddress
    {
        public Warehouse()
        {
            this.createdAt = DateTime.UtcNow;
        }

        [StringLength(38)]
        [Display(Name = "Warehouse Id")]
        public string warehouseId { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên kho")]
        [Required]
        public string warehouseName { get; set; }

        [StringLength(50)]
        [Display(Name = "Thông tin kho")]
        public string description { get; set; }

        [StringLength(38)]
        [Display(Name = "Công ty Id")]
        public string branchId { get; set; }
        
        [Display(Name = "Công ty")]
        public Branch branch { get; set; }

        //IBaseAddress
        [Display(Name = "Địa chỉ kho 1")]
        [Required]
        [StringLength(50)]
        public string street1 { get; set; }

        [Display(Name = "Địa chỉ kho 2")]
        [StringLength(50)]
        public string street2 { get; set; }

        [Display(Name = "Thành phố")]
        [StringLength(30)]
        public string city { get; set; }

        [Display(Name = "Tỉnh thành")]
        [StringLength(30)]
        public string province { get; set; }

        [Display(Name = "Quốc gia")]
        [StringLength(30)]
        public string country { get; set; }
        //IBaseAddress
    }
}
