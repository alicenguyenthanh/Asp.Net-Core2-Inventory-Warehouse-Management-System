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
        [Display(Name = "Job Title")]
        [Required]
        public string jobTitle { get; set; }

        [StringLength(38)]
        [Display(Name = "Customer Id")]
        public string customerId { get; set; }

        [Display(Name = "Customer")]
        public Customer customer { get; set; }

        //IBasePerson
        [Display(Name = "First Name")]
        [Required]
        [StringLength(20)]
        public string firstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [StringLength(20)]
        public string lastName { get; set; }

        [Display(Name = "Middle Name")]
        [StringLength(20)]
        public string middleName { get; set; }

        [Display(Name = "Nick Name")]
        [StringLength(20)]
        public string nickName { get; set; }

        [Display(Name = "Gender")]
        public Gender gender { get; set; }

        [Display(Name = "Salutation")]
        public Salutation salutation { get; set; }
        //IBasePerson

        //IBaseCommunication
        [Display(Name = "Mobile Phone")]
        [StringLength(20)]
        public string mobilePhone { get; set; }

        [Display(Name = "Office Phone")]
        [StringLength(20)]
        public string officePhone { get; set; }

        [Display(Name = "Fax")]
        [StringLength(20)]
        public string fax { get; set; }

        [Display(Name = "Personal Email")]
        [StringLength(50)]
        public string personalEmail { get; set; }

        [Display(Name = "Work Email")]
        [StringLength(50)]
        public string workEmail { get; set; }
        //IBaseCommunication
    }
}
