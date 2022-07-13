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
    public class GetMembersQueryHandler : IRequestHandler<GetMembersQuery, List<MemberDto>>
    {
        private readonly IMembersService _membersService;

        public GetMembersQueryHandler(IMembersService membersService)
        {
            _membersService = membersService;
        }

        public async Task<List<MemberDto>> Handle(GetMembersQuery request, CancellationToken cancellationToken)
        {
            return await _membersService.GetAllAsync();
        }
    }
}
