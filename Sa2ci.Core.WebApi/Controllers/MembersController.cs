using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sa2ci.Core.Bll.Dtos;
using Sa2ci.Core.Bll.Queries;

namespace Sa2ci.Core.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MembersController : ControllerBase
    {   
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public MembersController(ILogger<MembersController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("[action]")] 
        public async Task<IList<MemberDto>> GetAll ()
        {
            return await _mediator.Send(new GetMembersQuery());
        }
    }
}