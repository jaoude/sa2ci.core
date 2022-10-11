using MediatR;
using Sa2ci.Core.Bll.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sa2ci.Core.Bll.Queries
{
    public record LoginQuery : IRequest<LoginResultDto>
    {
        public LoginRequestDto Request { get; set; }

        public LoginQuery(LoginRequestDto request)
        {
            Request = request;
        }
    }
}
