using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SPH.HoaHC.DataGov.Samples
{
    public interface ISampleAppService : IApplicationService
    {
        Task<SampleDto> GetAsync();

        Task<SampleDto> GetAuthorizedAsync();
    }
}
