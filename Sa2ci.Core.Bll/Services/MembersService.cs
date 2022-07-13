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
    public class MembersService : IMembersService
    {
        private readonly Sa2ciCoreContext _context;
        private readonly IMapper _mapper;

        public MembersService(Sa2ciCoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MemberDto>> GetAllAsync()
        {
            var result = await _context.Members
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return result;
        }
    }
}
