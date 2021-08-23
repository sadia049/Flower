using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerBouquet.Models
{
    public class MemberRole
    {
        [Key]
        public int MemberRoleID { get; set; }

        public int MemberID { get; set; }
        [ForeignKey("MemberID")]

        public virtual Member Members { get; set; }

        public int RoleID { get; set; }
        [ForeignKey("RoleID")]
        public virtual Role Roles { get; set; }
    }
}