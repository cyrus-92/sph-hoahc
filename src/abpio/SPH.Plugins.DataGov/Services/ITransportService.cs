using System.Threading;
using System.Threading.Tasks;

namespace SPH.Plugins.DataGov.Services
{
    public interface ITransportService
    {
        Task<bool> GetCarparkAvailabilityAsync(string dateTime, CancellationToken cancellationToken = default);
    }
}
