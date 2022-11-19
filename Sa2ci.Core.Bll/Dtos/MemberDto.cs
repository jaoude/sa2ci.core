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
        public int ID { get; set; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }

        public override string ToString()
        {
            return $"ID : {ID}, FirstName : {FirstName}, LastName : {LastName}";
        }
    }
}
