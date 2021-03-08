using Newtonsoft.Json;
using System.Collections.Generic;

namespace SPH.Model.DataGov
{
    public class CarparkAvailabilityModel
    {
        [JsonProperty("carpark_data")]
        public IEnumerable<CarparkModel> Carparks { get; set; }
    }
}
