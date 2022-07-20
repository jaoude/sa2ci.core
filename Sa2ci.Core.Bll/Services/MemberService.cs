using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Sa2ci.Core.Bll.Dtos;
using Sa2ci.Core.Dal.Data;
using Sa2ci.Core.Dal.Data.Entities;

namespace Sa2ci.Core.Bll.Services
{
    public class MemberService : IMemberService
    {
        private readonly Sa2ciCoreContext _context;
        private readonly IMapper _mapper;

        public MemberService(Sa2ciCoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MemberDto>> GetMembersAsync()
        {

            //var result = await _context.Members
            //    .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
            //    .ToListAsync();

            var result = await Task.FromResult(Using_The_Faker_Facade());

            return result;
        }

        public List<MemberDto> Using_The_Faker_Facade()
        {
            var faker = new Faker<MemberDto>()
                .RuleFor(o => o.FirstName, f => f.Person.FirstName)
                .RuleFor(o => o.LastName, f => f.Person.LastName)
                .RuleFor(o => o.Email, f => f.Person.Email)
                .RuleFor(o => o.DOB, f => f.Person.DateOfBirth);

            var result = new List<MemberDto>();
            for (int i = 1; i <= 500; i++)
            {
                var MemberDto = (MemberDto)faker;
                MemberDto.ID = i;
                result.Add(MemberDto);
            }

            return result;
        }
    }
}
