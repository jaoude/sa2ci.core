using Sa2ci.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sa2ci.Core.Bll.Dtos
{
    [ExportToTypescript]
    public class LoginResultDto
    { 
        public string AccessToken { get; set; }
        public string TokenType { get; set; } = "Bearer";
        public int ExpiresIn { get; set; } = 3600;
        public string UserName { get; set; } 
    }
}
