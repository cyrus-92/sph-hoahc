using Newtonsoft.Json;
using System.Collections.Generic;

namespace SPH.HoaHC.DataGov.Transports
{
    public class CarparkAvailabilityModel
    {
        [JsonProperty("carpark_data")]
        public IEnumerable<CarparkModel> Carparks { get; set; }
    }
}
