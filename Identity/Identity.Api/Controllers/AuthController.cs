using Identity.Application;
using Identity.Application.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<ServiceResultDto<string>>> Login([FromBody] Login.Command command)
        {
            var result = await this.Mediator.Send(command);
            return result.IsSuccess ? (ActionResult<ServiceResultDto<string>>)this.Ok(result) : this.BadRequest(result);
        }
    }
}