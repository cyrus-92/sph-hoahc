using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace SPH.HoaHC.DataGov.Samples
{
    public class SampleAppService : DataGovAppService, ISampleAppService
    {
        public Task<SampleDto> GetAsync()
        {
            return Task.FromResult(
                new SampleDto
                {
                    Value = 42
                }
            );
        }

        [Authorize]
        public Task<SampleDto> GetAuthorizedAsync()
        {
            return Task.FromResult(
                new SampleDto
                {
                    Value = 42
                }
            );
        }
    }
}