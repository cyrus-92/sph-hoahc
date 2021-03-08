using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SPH.Model.DataGov;
using SPH.Service.DataGov;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WeLott.Model.Abstractions.Responses;

namespace SPH.Api.Controllers
{
    public class DataGovController : BaseController
    {
        protected readonly ITransportService transportService;

        public DataGovController(ILogger<DataGovController> logger, ITransportService transportService) : base(logger)
        {
            this.transportService = transportService ?? throw new ArgumentNullException(nameof(transportService));
        }

        [HttpGet]
        [Route("api/transports/carpark_availability")]
        [ProducesResponseType(typeof(OkResponseModel<IEnumerable<CarparkModel>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCarparkAvailability([FromQuery(Name = "date_time")] string dateTime, CancellationToken cancellationToken = default)
            => Ok(await transportService.GetCarparkAvailabilityAsync(dateTime, cancellationToken));
    }
}
