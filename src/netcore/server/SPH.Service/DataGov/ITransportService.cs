using SPH.Model.DataGov;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WeLott.Model.Abstractions.Responses;

namespace SPH.Service.DataGov
{
    public interface ITransportService
    {
        Task<OkResponseModel<IEnumerable<CarparkModel>>> GetCarparkAvailabilityAsync(string dateTime, CancellationToken cancellationToken = default);
    }
}
