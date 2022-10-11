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
        private readonly IMemberService _memberService;

        public GetMembersQueryHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }

        public async Task<List<MemberDto>> Handle(GetMembersQuery request, CancellationToken cancellationToken)
        {
            return await _memberService.GetMembersAsync();
        }
    }
}
