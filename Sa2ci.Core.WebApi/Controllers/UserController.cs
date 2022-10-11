using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sa2ci.Core.Bll.Dtos;
using Sa2ci.Core.Bll.Queries;

namespace Sa2ci.Core.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {   
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<LoginResultDto> Login([FromQuery]LoginRequestDto loginRequest)
        {
            var query = new LoginQuery(loginRequest);
            var result = await _mediator.Send(query);
            return result;
        }
    }
}