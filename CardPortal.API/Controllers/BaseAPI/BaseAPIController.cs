using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CardPortal.API.Controllers.BaseAPI
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseAPIController : ControllerBase
    {
        private IMediator? _mediator;

        protected IMediator Mediator => _mediator ??=
            HttpContext.RequestServices.GetService<IMediator>()!;
    }
}
