using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SPH.Model.Abstractions.Responses;
using SPH.Model.Users;
using SPH.Service.Users;
using System;
using System.Threading;
using System.Threading.Tasks;
using WeLott.Model.Abstractions.Responses;

namespace SPH.Api.Controllers
{
    public class UserController : BaseController
    {
        protected readonly IUserService userService;

        public UserController(ILogger<UserController> logger, IUserService userService) : base(logger)
        {
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(OkResponseModel<BaseResponseModel>), StatusCodes.Status200OK)]
        [Route("api/users/sign_up")]
        public async Task<IActionResult> SignUpAsync([FromBody] UserRegistrationModel registerUser, CancellationToken cancellationToken = default)
            => Ok(await userService.SignUpAsync(registerUser, cancellationToken));

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(AuthorizedResponseModel), StatusCodes.Status200OK)]
        [Route("api/users/sign_in")]
        public async Task<IActionResult> SignInAsync([FromBody] UserLoginModel loginUser, CancellationToken cancellationToken = default)
            => Ok(await userService.SignInAsync(loginUser, cancellationToken));

        [HttpGet]
        [Route("api/users/me")]
        [ProducesResponseType(typeof(OkResponseModel<UserProfileModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProfileAsync(CancellationToken cancellationToken = default)
            => Ok(await userService.GetProfileAsync(cancellationToken));
    }
}
