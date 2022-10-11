using MediatR;
using Sa2ci.Core.Bll.Dtos;
using Sa2ci.Core.Bll.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sa2ci.Core.Bll.Queries
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginResultDto>
    {
        private readonly IUserService _userService;

        public LoginQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<LoginResultDto> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            return await _userService.LoginAsync(query.Request.Email, query.Request.Password);
        }
    }
}
