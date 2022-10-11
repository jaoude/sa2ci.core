using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sa2ci.Core.Dal.Data.Entities
{
    [Table("UserRole")]
    public class UserRole
    {
        [Key, Column(Order = 1)]
        public Guid UserID { get; set; }
        [Key, Column(Order = 2)]
        public Guid RoleID{ get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
