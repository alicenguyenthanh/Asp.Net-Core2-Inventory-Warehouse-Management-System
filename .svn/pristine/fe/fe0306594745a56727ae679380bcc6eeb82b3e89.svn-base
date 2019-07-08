using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netcore.Models.Invent
{
    public class Vendor : INetcoreMasterChild, IBaseAddress
    {
        public Vendor()
        {
            this.createdAt = DateTime.UtcNow;
        }

        [StringLength(38)]
        [Display(Name = "Vendor Id")]
        public string vendorId { get; set; }

        [StringLength(50)]
        [Display(Name = "Vendor Name")]
        [Required]
        public string vendorName { get; set; }

        [StringLength(50)]
        [Display(Name = "Description")]
        public string description { get; set; }
        
        [Display(Name = "Business Size")]
        public BusinessSize size { get; set; }

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

        [Display(Name = "Vendor Contacts")]
        public List<VendorLine> vendorLine { get; set; } = new List<VendorLine>();
    }
}
