using AutoMapper;
using BZPAY_BE.DataAccess;
using BZPAY_BE.Models;
using BZPAY_BE.Repositories.Implementations;
using System;

namespace BZPAY_BE.Common.Profiles
{
	/// <summary>
	/// Mapping Profile for Aspnet User
	/// </summary>
	public class AspnetUserProfile2: Profile
	{
		/// <summary>
		/// Constructor Method for mapping profile
		/// </summary>
		public AspnetUserProfile2()
		{
            AspnetUserMapper(CreateMap<AspnetUser, AspnetUserDo>());
		}

        /// <summary>
        /// Mapped AspnetUser to AspnetUserDo
        /// </summary>
        /// <param name="mappingExpression"></param>
        private void AspnetUserMapper(IMappingExpression<AspnetUser, AspnetUserDo> mappingExpression)
        {
            mappingExpression.ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
                             .ForMember(dest => dest.UserName, act => act.MapFrom(src => src.))
                             .ForMember(dest => dest.UserName, act => act.MapFrom(src => src.UserName))
                             .ForMember(dest => dest.LoweredUserName, act => act.MapFrom(src => src.LoweredUserName))
                             .ForMember(dest => dest.MobileAlias, opt => opt.MapFrom(src => src.MobileAlias))
                             .ForMember(dest => dest.IsAnonymous, act => act.MapFrom(src => src.IsAnonymous))
                             .ForMember(dest => dest.LastActivityDate, opt => opt.MapFrom(src => src.LastActivityDate))
                             .ForMember(dest => dest.UserId, act => act.MapFrom(src => src.UserId))
                             .ForMember(dest => dest.UserName, act => act.MapFrom(src => src.UserName))
                             .ForMember(dest => dest.LoweredUserName, act => act.MapFrom(src => src.LoweredUserName))
                             .ForMember(dest => dest.MobileAlias, opt => opt.MapFrom(src => src.MobileAlias))
                             .ForMember(dest => dest.IsAnonymous, act => act.MapFrom(src => src.IsAnonymous))
                             .ForMember(dest => dest.LastActivityDate, opt => opt.MapFrom(src => src.LastActivityDate));
        }

    }
}
