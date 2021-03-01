using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Provider.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private IMediator mediator;

        /// <summary>
        /// Gets Mediator.
        /// </summary>
        protected IMediator Mediator => this.mediator ?? (this.mediator = this.HttpContext.RequestServices.GetService<IMediator>());
    }
}