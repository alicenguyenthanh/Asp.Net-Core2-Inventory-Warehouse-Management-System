using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netcore.Models.Invent
{
    public class CustomerLine : INetcoreBasic, IBasePerson, IBaseCommunication
    {
        public CustomerLine()
        {
            this.createdAt = DateTime.UtcNow;
        }

        [StringLength(38)]
        [Display(Name = "Customer Line Id")]
        public string customerLineId { get; set; }

        [StringLength(20)]
        [Display(Name = "Chức danh công việc")]
        [Required]
        public string jobTitle { get; set; }

        [StringLength(38)]
        [Display(Name = "Customer Id")]
        public string customerId { get; set; }

        [Display(Name = "Khách hàng")]
        public Customer customer { get; set; }

        //IBasePerson
        [Display(Name = "Tên")]
        [Required]
        [StringLength(20)]
        public string firstName { get; set; }

        [Display(Name = "Họ tên lót")]
        [Required]
        [StringLength(20)]
        public string lastName { get; set; }

        [Display(Name = "Bí danh")]
        [StringLength(20)]
        public string middleName { get; set; }

        [Display(Name = "Nick Name")]
        [StringLength(20)]
        public string nickName { get; set; }

        [Display(Name = "Giới tính")]
        public Gender gender { get; set; }

        [Display(Name = "Salutation")]
        public Salutation salutation { get; set; }
        //IBasePerson

        //IBaseCommunication
        [Display(Name = "Di động")]
        [StringLength(20)]
        public string mobilePhone { get; set; }

        [Display(Name = "Điện thoại cty")]
        [StringLength(20)]
        public string officePhone { get; set; }

        [Display(Name = "Fax")]
        [StringLength(20)]
        public string fax { get; set; }

        [Display(Name = "Email cá nhân")]
        [StringLength(50)]
        public string personalEmail { get; set; }

        [Display(Name = "Email công việc")]
        [StringLength(50)]
        public string workEmail { get; set; }
        //IBaseCommunication
    }
}
