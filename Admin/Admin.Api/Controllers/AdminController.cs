using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Application.Commands;
using Admin.Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : BaseController
    {
        [HttpGet]
        public async Task<List<string>> GetUnAssignedRequests()
        {
            var query = new GetUnAssignedRequests.Query();
            return await this.Mediator.Send(query);
        }


        [HttpPost]
        public async Task<bool> AssignRequestToProvider(AssignRequestToProvider.Command command)
        {
            return await this.Mediator.Send(command);
        }
    }
}