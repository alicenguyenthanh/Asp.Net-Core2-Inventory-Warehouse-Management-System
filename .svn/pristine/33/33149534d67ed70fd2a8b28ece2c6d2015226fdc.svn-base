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
        [Display(Name = "Warehouse Name")]
        [Required]
        public string warehouseName { get; set; }

        [StringLength(50)]
        [Display(Name = "Warehouse Description")]
        public string description { get; set; }

        [StringLength(38)]
        [Display(Name = "Branch Id")]
        public string branchId { get; set; }
        
        [Display(Name = "Branch")]
        public Branch branch { get; set; }

        //IBaseAddress
        [Display(Name = "Street Address 1")]
        [Required]
        [StringLength(50)]
        public string street1 { get; set; }

        [Display(Name = "Street Address 2")]
        [StringLength(50)]
        public string street2 { get; set; }

        [Display(Name = "City")]
        [StringLength(30)]
        public string city { get; set; }

        [Display(Name = "Province")]
        [StringLength(30)]
        public string province { get; set; }

        [Display(Name = "Country")]
        [StringLength(30)]
        public string country { get; set; }
        //IBaseAddress
    }
}
