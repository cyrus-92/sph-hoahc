using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;

namespace SPH.HoaHC.DataGov.Transports
{
    [RemoteService]
    [Route("api/DataGov/transports")]
    public class TransportController : DataGovController, ITransportService
    {
        private readonly ITransportService _transportService;

        public TransportController(ITransportService transportService)
        {
            _transportService = transportService;
        }

        [HttpGet]
        [Authorize]
        [Route("carpark_availability")]
        public async Task<IEnumerable<CarparkModel>> GetCarparkAvailabilityAsync(string dateTime, CancellationToken cancellationToken = default)
        {
            return await _transportService.GetCarparkAvailabilityAsync(dateTime, cancellationToken);
        }
    }
}
