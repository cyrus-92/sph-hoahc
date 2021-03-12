using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace SPH.Plugins.DataGov.Services
{
    public class TransportService : ITransientDependency, ITransportService
    {
        private readonly ILogger<TransportService> logger;

        public TransportService(ILogger<TransportService> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> GetCarparkAvailabilityAsync(string dateTime, CancellationToken cancellationToken = default)
        {
            logger.LogInformation("[TransportService][GetCarparkAvailabilityAsync] TransportService has been initialized.");

            return true;
        }
    }
}
