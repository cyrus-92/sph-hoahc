using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SPH.Entity.Users;
using SPH.Infrastructure.Abstractions;
using SPH.Infrastructure.UoW;
using SPH.Model.Abstractions.Responses;
using SPH.Model.Users;
using SPH.Shared.Configurations;
using SPH.Shared.Extensions;
using SPH.Shared.Helpers;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeLott.Model.Abstractions.Responses;
using WeLott.Shared.Exceptions;

namespace SPH.Service.Users
{
    public class UserService : IUserService
    {
        protected readonly ISPHUoW sphUoW;
        protected readonly IRepository<User> userRepository;
        protected readonly IMapper mapper;
        protected readonly JwtSetting jwtSetting;
        protected readonly Guid currentUserId;

        public UserService(ISPHUoW sphUoW, IConfiguration configuration, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.sphUoW = sphUoW ?? throw new ArgumentNullException(nameof(sphUoW));
            userRepository = sphUoW.GetRepository<User>();
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            jwtSetting = configuration.GetOptions<JwtSetting>();
            currentUserId = httpContextAccessor.GetCurrentUserId();
        }

        public async Task<OkResponseModel<UserProfileModel>> GetProfileAsync(CancellationToken cancellationToken = default)
        {
            var user = await userRepository.GetAsync(
                predicate: u => u.UserId == currentUserId,
                cancellationToken: cancellationToken
            );
            if (user == null)
                throw new BadRequestException("The request is invalid.");

            return new OkResponseModel<UserProfileModel>(mapper.Map<UserProfileModel>(user));
        }

        public async Task<AuthorizedResponseModel> SignInAsync(UserLoginModel loginUser, CancellationToken cancellationToken = default)
        {
            var user = await userRepository.GetAsync(
                predicate: u => u.Email == loginUser.Email,
                cancellationToken: cancellationToken
            );
            if (user == null)
                return new AuthorizedResponseModel("The email or password is invalid.");

            var passwordHashed = CryptoHelper.Encrypt(loginUser.Password, user.PasswordSalt);
            if (!passwordHashed.Equals(user.PasswordHashed))
                return new AuthorizedResponseModel("The username or password is invalid.");

            var refreshToken = Guid.NewGuid().ToString();
            var issuedTime = DateTime.UtcNow;
            var expiredTime = issuedTime.AddMinutes(jwtSetting.ExpiredMinute);

            var claims = new Claim[]
            {
                new Claim("rid", refreshToken),
                new Claim("uid", user.UserId.ToString()),
                new Claim("urn", user.Email)
            };
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var tokenDescription = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Audience = jwtSetting.Audience,
                Issuer = jwtSetting.Issuer,
                Expires = expiredTime,
                IssuedAt = issuedTime,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSetting.Key)), SecurityAlgorithms.HmacSha256Signature)
            };
            var accessToken = jwtTokenHandler.WriteToken(jwtTokenHandler.CreateToken(tokenDescription));

            return new AuthorizedResponseModel(accessToken, refreshToken, issuedTime, expiredTime);
        }

        public async Task<BaseResponseModel> SignUpAsync(UserRegistrationModel registerUser, CancellationToken cancellationToken = default)
        {
            var existUser = await userRepository.GetAsync(
                predicate: u => u.Email == registerUser.Email,
                cancellationToken: cancellationToken
            );
            if (existUser != null)
                throw new BadRequestException("The email is not available.");

            var newUser = mapper.Map<User>(registerUser);
            await userRepository.InsertAsync(newUser, cancellationToken);
            await sphUoW.SaveChangesAsync(cancellationToken);

            return new BaseResponseModel();
        }
    }
}
