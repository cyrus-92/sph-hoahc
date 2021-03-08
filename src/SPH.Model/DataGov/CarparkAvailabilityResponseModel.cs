using Newtonsoft.Json;
using System.Collections.Generic;

namespace SPH.Model.DataGov
{
    public class CarparkAvailabilityResponseModel
    {
        [JsonProperty("items")]
        public IEnumerable<CarparkAvailabilityModel> CarparkAvailabilities { get; set; }
    }
}
