using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerBouquet.Models
{
    public class Role
    {
       
            [Key]
            public int RoleID { get; set; }
            [Required(ErrorMessage = "Member Role Name is required")]
            [StringLength(100, MinimumLength = 3)]
            public string RoleName { get; set; }
            public virtual ICollection<Member> Members { get; set; }
        

    }
}