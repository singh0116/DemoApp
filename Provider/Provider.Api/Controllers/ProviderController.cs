using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Provider.Api.Helpers.Interface;
using Provider.Application.Commands;
using Provider.Application.Queries;
using Provider.Domain.Entities;

namespace Provider.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProviderController : BaseController
    {
        private IUserAccessor userAccessor;
        public ProviderController(IUserAccessor userAccessor)
        {
            this.userAccessor = userAccessor;
        }

        [HttpGet]
        public async Task<List<Job>> GetPendingJobsOfUser()
        {
            var userId = this.userAccessor.GetUserId();
            var query = new GetPendingJobsOfUser.Query { ProviderUserId = userId };
            return await this.Mediator.Send(query);
        }

        [HttpPost]
        public async Task<bool> AcceptOrRejectJob(AcceptOrRejectJob.Command command)
        {
            return await this.Mediator.Send(command);
        }
    }
}