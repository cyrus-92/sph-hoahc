using Newtonsoft.Json;
using System.Collections.Generic;

namespace SPH.HoaHC.DataGov.Transports
{
    public class CarparkAvailabilityResponseModel
    {
        [JsonProperty("items")]
        public IEnumerable<CarparkAvailabilityModel> CarparkAvailabilities { get; set; }
    }
}
