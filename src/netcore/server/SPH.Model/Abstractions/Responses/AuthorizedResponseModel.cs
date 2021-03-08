using Newtonsoft.Json;
using SPH.Shared.Extensions;
using System;
using System.Net;
using WeLott.Model.Abstractions.Responses;

namespace SPH.Model.Abstractions.Responses
{
    public class AuthorizedResponseModel : BaseResponseModel
    {
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "expires_in")]
        public long? ExpiredIn { get; set; }

        [JsonProperty(PropertyName = "refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty(PropertyName = "token_type")]
        public string TokenType => "bearer";

        public AuthorizedResponseModel() { }

        public AuthorizedResponseModel(string errorMessage)
        {
            ErrorMessage = errorMessage;
            StatusCode = HttpStatusCode.Unauthorized;
        }

        public AuthorizedResponseModel(string accessToken, string refreshToken, DateTime issuedTime, DateTime expiredTime)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            ExpiredIn = issuedTime.ToDifference(expiredTime);
            StatusCode = HttpStatusCode.OK;
        }
    }
}
