using Sa2ci.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sa2ci.Core.Bll.Dtos
{
    [ExportToTypescript]
    public class UserDto
    { 
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Email{ get; set; }
        public List<string> Roles { get; set; }
    }
}
