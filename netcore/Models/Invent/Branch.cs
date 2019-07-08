using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netcore.Models.Invent
{
    public class Branch: INetcoreBasic, IBaseAddress
    {
        public Branch()
        {
            this.createdAt = DateTime.UtcNow;
            this.isDefaultBranch = false;
        }

        [StringLength(38)]
        [Display(Name = "Id công ty")]
        public string branchId { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên công ty")]
        [Required]
        public string branchName { get; set; }

        [StringLength(50)]
        [Display(Name = "Thông tin công ty")]
        public string description { get; set; }

        [Display(Name = "Chọn công ty là trụ sở chính ?")]
        public bool isDefaultBranch { get; set; } = false;

        //IBaseAddress
        [Display(Name = "Địa chỉ 1")]
        [Required]
        [StringLength(50)]
        public string street1 { get; set; }

        [Display(Name = "Địa chỉ 2")]
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
