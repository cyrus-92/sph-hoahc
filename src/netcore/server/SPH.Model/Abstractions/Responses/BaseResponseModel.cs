using Newtonsoft.Json;
using System.Net;

namespace WeLott.Model.Abstractions.Responses
{
    public class BaseResponseModel
    {
        [JsonProperty("code")]
        public HttpStatusCode StatusCode { get; set; }

        [JsonProperty("error")]
        public string ErrorMessage { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("status")]
        public bool Status
        {
            get
            {
                return string.IsNullOrEmpty(ErrorMessage);
            }
        }

        public BaseResponseModel()
        {
            StatusCode = HttpStatusCode.OK;
        }

        public BaseResponseModel(HttpStatusCode statusCode, string errorMessage)
        {
            ErrorMessage = errorMessage;
            StatusCode = statusCode;
        }
    }
}
