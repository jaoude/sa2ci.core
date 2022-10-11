using Sa2ci.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sa2ci.Core.Bll.Dtos
{
    [ExportToTypescript]
    public class LoginRequestDto
    { 
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
