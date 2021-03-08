using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;

namespace SPH.Shared.Extensions
{
    public static class HttpContextExtensions
    {
        public static Guid GetCurrentUserId(this IHttpContextAccessor contextAccessor)
        {
            if (contextAccessor == null)
                throw new ArgumentNullException(nameof(contextAccessor));

            if (!contextAccessor.HttpContext.User.Identity.IsAuthenticated)
                return Guid.Empty;

            return contextAccessor.HttpContext.User.GetCurrentUserId();
        }

        public static Guid GetCurrentUserId(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal == null || !claimsPrincipal.Claims.NotNullOrEmpty())
                throw new ArgumentNullException(nameof(claimsPrincipal));

            var claim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "uid");
            if (claim == null)
                throw new ArgumentNullException(nameof(claim));

            return Guid.Parse(claim.Value);
        }
    }
}
