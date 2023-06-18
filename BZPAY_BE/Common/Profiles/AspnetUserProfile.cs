using AutoMapper;
using BZPAY_BE.DataAccess;
using BZPAY_BE.Models;
using System;

namespace BZPAY_BE.Common.Profiles
{
    public class AspnetuserProfile : Profile
    {

        public AspnetuserProfile()
        {
            AspnetuserMapper(CreateMap<AspnetUser, AspnetUserDo>());
        }

        private void AspnetuserMapper(IMappingExpression<AspnetUser, AspnetUserDo> mappingExpression)
        {
            mappingExpression.ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, act => act.MapFrom(src => src.UserName))
                .ForMember(dest => dest.NormalizedUserName, act => act.MapFrom(src => src.NormalizedUserName))
                .ForMember(dest => dest.Email, act => act.MapFrom(src => src.Email))
                .ForMember(dest => dest.NormalizedEmail, act => act.MapFrom(src => src.NormalizedEmail))
                .ForMember(dest => dest.EmailConfirmed, act => act.MapFrom(src => src.EmailConfirmed))
                .ForMember(dest => dest.PasswordHash, act => act.MapFrom(src => src.PasswordHash))
                .ForMember(dest => dest.SecurityStamp, act => act.MapFrom(src => src.SecurityStamp))
                .ForMember(dest => dest.ConcurrencyStamp, act => act.MapFrom(src => src.ConcurrencyStamp))
                .ForMember(dest => dest.PhoneNumber, act => act.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.PhoneNumberConfirmed, act => act.MapFrom(src => src.PhoneNumberConfirmed))
                .ForMember(dest => dest.TwoFactorEnabled, act => act.MapFrom(src => src.TwoFactorEnabled))
                .ForMember(dest => dest.LockoutEnd, act => act.MapFrom(src => src.LockoutEnd))
                .ForMember(dest => dest.LockoutEnabled, act => act.MapFrom(src => src.LockoutEnabled))
                .ForMember(dest => dest.AccessFailedCount, act => act.MapFrom(src => src.AccessFailedCount));

        }
    }
}