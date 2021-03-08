using AutoMapper;
using Microsoft.Extensions.Configuration;
using SPH.Entity.Users;
using SPH.Model.Users;
using SPH.Shared.Configurations;
using SPH.Shared.Extensions;
using SPH.Shared.Helpers;
using System;

namespace SPH.Service.Mapping.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile(IConfiguration configuration)
        {
            var jwtSetting = configuration.GetOptions<JwtSetting>();

            CreateMap<UserRegistrationModel, User>()
                .AfterMap((src, dest) =>
                {
                    dest.UserId = Guid.NewGuid();
                    dest.PasswordSalt = CryptoHelper.GenerateKey();
                    dest.PasswordHashed = CryptoHelper.Encrypt(src.Password, dest.PasswordSalt);
                    dest.CreatedTime = DateTime.UtcNow;
                });

            CreateMap<User, UserProfileModel>();
        }
    }
}
