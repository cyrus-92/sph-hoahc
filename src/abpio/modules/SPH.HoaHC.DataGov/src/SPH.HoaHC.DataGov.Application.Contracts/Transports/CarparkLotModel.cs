using Newtonsoft.Json;

namespace SPH.HoaHC.DataGov.Transports
{
    public class CarparkLotModel
    {
        [JsonProperty("total_lots")]
        public int TotalSlots { get; set; }

        [JsonProperty("lot_type")]
        public string Type { get; set; }

        [JsonProperty("lots_available")]
        public int Available { get; set; }
    }
}
