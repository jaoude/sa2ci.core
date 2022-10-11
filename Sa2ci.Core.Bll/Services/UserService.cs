using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Sa2ci.Core.Bll.Dtos;
using Sa2ci.Core.Bll.Helpers;
using Sa2ci.Core.Common;
using Sa2ci.Core.Dal.Data;
using Sa2ci.Core.Dal.Data.Entities;
using System.Text;

namespace Sa2ci.Core.Bll.Services
{
    public class UserService : IUserService
    {
        private readonly Sa2ciCoreContext _context;
        private readonly IMapper _mapper;

        public UserService(Sa2ciCoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LoginResultDto> LoginAsync(string email, string password)
        {
            var result = new LoginResultDto();
            var passwordHash = password.ToSha256();

            var user = await _context.Users
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .FirstOrDefaultAsync(x => x.Email == email && x.Password == passwordHash);

            if (user != null)
            {
                result.AccessToken = new GenerateToken(user).Token;
                result.UserName = user.Name;
            }

            return result;
        }
    }
}
