using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SPH.HoaHC.DataGov.Transports
{
    public interface ITransportService : IApplicationService
    {
        Task<IEnumerable<CarparkModel>> GetCarparkAvailabilityAsync(string dateTime, CancellationToken cancellationToken = default);
    }
}
