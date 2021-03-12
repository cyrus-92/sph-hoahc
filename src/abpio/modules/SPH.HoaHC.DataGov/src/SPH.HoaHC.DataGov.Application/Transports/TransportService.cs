using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPH.HoaHC.DataGov.Transports
{
    public class TransportService : DataGovAppService, ITransportService
    {
        private static readonly string domain = @"https://api.data.gov.sg";

        [Authorize]
        public async Task<IEnumerable<CarparkModel>> GetCarparkAvailabilityAsync(string dateTime, CancellationToken cancellationToken = default)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(domain);

                var response = await httpClient.GetAsync(string.Format("{0}{1}", @"v1/transport/carpark-availability", string.IsNullOrEmpty(dateTime) ? string.Empty : "?date_time=" + dateTime));
                if (response.IsSuccessStatusCode)
                {
                    var raw = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(raw))
                    {
                        var carparkAvailabilityResponse = JsonConvert.DeserializeObject<CarparkAvailabilityResponseModel>(raw);
                        if (carparkAvailabilityResponse != null && carparkAvailabilityResponse.CarparkAvailabilities != null && carparkAvailabilityResponse.CarparkAvailabilities.Any())
                            return carparkAvailabilityResponse.CarparkAvailabilities.SelectMany(ca => ca.Carparks).ToList();
                    }
                }
            }

            return new List<CarparkModel>();
        }
    }
}
