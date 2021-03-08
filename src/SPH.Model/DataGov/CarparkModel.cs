using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SPH.Model.DataGov
{
    public class CarparkModel
    {
        [JsonProperty("carpark_info")]
        public IEnumerable<CarparkLotModel> CarparkLots { get; set; }

        [JsonProperty("carpark_number")]
        public string Number { get; set; }

        [JsonProperty("update_datetime")]
        public DateTime LastModifiedTime { get; set; }
    }
}
