using Newtonsoft.Json;

namespace SPH.Model.Users
{
    public class UserRegistrationModel
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("contact_number")]
        public string ContactNumber { get; set; }
    }
}
