using Consumer.Api.Heplers.Interface;
using Consumer.Application.Commands;
using Consumer.Application.Queries;
using Consumer.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consumer.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class RequestController : BaseController
    {
        private IUserAccessor userAccessor;
        public RequestController(IUserAccessor userAccessor)
        {
            this.userAccessor = userAccessor;
        }

        [HttpGet]
        public async Task<List<ServiceRequest>> GetAllRequests()
        {
            var userId = this.userAccessor.GetUserId();
            var query = new GetAllRequests.Query { UserId = userId };
            return await this.Mediator.Send(query);
        }

        [HttpGet("{requestId}")]
        public async Task<ServiceRequest> GetRequestById(string requestId)
        {
            var query = new GetRequestById.Query { RequestId = requestId };
            return await this.Mediator.Send(query);
        }

        [HttpPost]
        public async Task<string> RequestService([FromBody] string serviceId)
        {
            var userId = this.userAccessor.GetUserId();
            var command = new RequestService.Command { ServiceId = serviceId, UserId = userId };
            return await this.Mediator.Send(command);
        }
    }
}