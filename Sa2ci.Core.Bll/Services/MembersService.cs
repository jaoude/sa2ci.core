using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Sa2ci.Core.Bll.Dtos;
using Sa2ci.Core.Dal.Data;
using Sa2ci.Core.Dal.Data.Entities;

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
            var bogusResult = new List<Member>();
            Using_The_Faker_Facade();
            var result = await _context.Members
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return result;
        }

        public void Using_The_Faker_Facade()
        {
            var faker = new Faker<Member>()
                .RuleFor(o => o.FirstName, f => f.Person.FirstName)
                .RuleFor(o => o.LastName, f => f.Person.LastName)
                .RuleFor(o => o.Email, f => f.Person.Email)
                .RuleFor(o => o.DOB, f => f.Date.PastDateOnly());

            var result = new List<Member>();
            for (int i = 1; i <= 500; i++)
            {
                ((Member)faker).ID = i;
               
                result.Add(faker);
            }

            
        }

    }
}
