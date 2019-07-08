using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netcore.Models.Invent
{
    public interface IBaseCommunication
    {
        [Display(Name = "Mobile Phone")]
        [StringLength(20)]
        string mobilePhone { get; set; }

        [Display(Name = "Office Phone")]
        [StringLength(20)]
        string officePhone { get; set; }

        [Display(Name = "Fax")]
        [StringLength(20)]
        string fax { get; set; }

        [Display(Name = "Personal Email")]
        [StringLength(50)]
        string personalEmail { get; set; }

        [Display(Name = "Work Email")]
        [StringLength(50)]
        string workEmail { get; set; }

    }
}
