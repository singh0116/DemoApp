using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Application.Query;
using Services.Domain.Entities;

namespace Services.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServicesController : BaseController
    {
        [HttpGet]
        public Task<List<Service>> GetAllServices()
        {
            var query = new GetAllServices.Query();
            return this.Mediator.Send(query);
        }

        [HttpGet("{serviceId}")]
        public Task<Service> GetServiceById(string serviceId)
        {
            var query = new GetServiceById.Query() { ServiceId = serviceId };
            return this.Mediator.Send(query);
        }

        [HttpGet("{serviceId}")]
        public Task<List<string>> GetProvidersByServiceId(string serviceId)
        {
            var query = new GetProvidersByServiceId.Query() { ServiceId = serviceId };
            return this.Mediator.Send(query);
        }
    }
}