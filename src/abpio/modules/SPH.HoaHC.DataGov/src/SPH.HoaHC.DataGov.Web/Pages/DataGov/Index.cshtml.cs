using Microsoft.AspNetCore.Authorization;
using SPH.HoaHC.DataGov.Transports;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SPH.HoaHC.DataGov.Web.Pages.DataGov
{
    [Authorize]
    public class IndexModel : DataGovPageModel
    {
        private readonly ITransportService _transportService;

        public IEnumerable<CarparkModel> carparkModels;

        public IndexModel(ITransportService transportService)
        {
            _transportService = transportService;
        }

        public async Task OnGetAsync(string dateTime)
        {
            carparkModels = await _transportService.GetCarparkAvailabilityAsync(dateTime);
        }
    }
}