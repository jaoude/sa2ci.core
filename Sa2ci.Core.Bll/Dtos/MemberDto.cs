using Sa2ci.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sa2ci.Core.Bll.Dtos
{
    [ExportToTypescript]
    public class MemberDto
    { 
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
