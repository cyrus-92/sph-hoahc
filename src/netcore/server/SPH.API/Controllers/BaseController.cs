using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace SPH.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    [EnableCors("CorsDEV")]
    public class BaseController : ControllerBase
    {
        protected readonly ILogger logger;

        public BaseController(ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
