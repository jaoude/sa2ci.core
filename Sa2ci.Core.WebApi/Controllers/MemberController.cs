using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sa2ci.Core.Bll.Dtos;
using Sa2ci.Core.Bll.Queries;

namespace Sa2ci.Core.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : ControllerBase
    {   
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public MemberController(ILogger<MemberController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("[action]")] 
        public async Task<List<MemberDto>> GetMembers()
        {
            var query = new GetMembersQuery();
            var result = await _mediator.Send(query);
            _logger.LogInformation(String.Join("\r\n", result.Select(c => c.ToString())));
            return result;
        }
    }
}