using AutoMapper;
using Sa2ci.Core.Bll.Dtos;
using Sa2ci.Core.Dal.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sa2ci.Core.Bll.Profiles
{
    public class MembersProfile : Profile
    {
        public MembersProfile()
        {
            CreateMap<Member, MemberDto>();
        } 
    }
}
