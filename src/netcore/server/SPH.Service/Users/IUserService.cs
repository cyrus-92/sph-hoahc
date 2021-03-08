using SPH.Model.Abstractions.Responses;
using SPH.Model.Users;
using System.Threading;
using System.Threading.Tasks;
using WeLott.Model.Abstractions.Responses;

namespace SPH.Service.Users
{
    public interface IUserService
    {
        Task<BaseResponseModel> SignUpAsync(UserRegistrationModel registerUser, CancellationToken cancellationToken = default);
        Task<AuthorizedResponseModel> SignInAsync(UserLoginModel loginUser, CancellationToken cancellationToken = default);
        Task<OkResponseModel<UserProfileModel>> GetProfileAsync(CancellationToken cancellationToken = default);
    }
}
