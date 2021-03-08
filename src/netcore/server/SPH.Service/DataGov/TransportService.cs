using Newtonsoft.Json;
using SPH.Model.DataGov;
using SPH.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WeLott.Model.Abstractions.Responses;

namespace SPH.Service.DataGov
{
    public class TransportService : ITransportService
    {
        private static readonly string domain = @"https://api.data.gov.sg";

        public async Task<OkResponseModel<IEnumerable<CarparkModel>>> GetCarparkAvailabilityAsync(string dateTime, CancellationToken cancellationToken = default)
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
                        if (carparkAvailabilityResponse != null && carparkAvailabilityResponse.CarparkAvailabilities.NotNullOrEmpty())
                            return new OkResponseModel<IEnumerable<CarparkModel>>(carparkAvailabilityResponse.CarparkAvailabilities.SelectMany(ca => ca.Carparks));
                    }
                }
            }

            return new OkResponseModel<IEnumerable<CarparkModel>>(new List<CarparkModel>());
        }
    }
}
