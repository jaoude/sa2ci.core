using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Sa2ci.Core.Bll.Dtos;
using Sa2ci.Core.Bll.Profiles;
using Sa2ci.Core.Dal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sa2ci.Core.Bll.Services
{
    public interface IMembersService
    {
        Task<List<MemberDto>> GetAllAsync();
    }
}
