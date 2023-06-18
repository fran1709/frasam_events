﻿using AutoMapper;
using BZPAY_BE.DataAccess;
using BZPAY_BE.Models;
using devTicket.Models;

namespace BZPAY_BE.Common.Profiles
{
    public class DetalleEventoProfile : Profile
    {
         public DetalleEventoProfile()
        {
            DetalleEventoMapper(CreateMap<DetalleEvento, DetalleEventoDo>());
        }

        private void DetalleEventoMapper(IMappingExpression<DetalleEvento, DetalleEventoDo> mappingExpression)
        {
            mappingExpression.ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
               .ForMember(dest => dest.Descripcion, act => act.MapFrom(src => src.Descripcion))
               .ForMember(dest => dest.TipoEvento, act => act.MapFrom(src => src.TipoEvento))
               .ForMember(dest => dest.Fecha, act => act.MapFrom(src => src.Fecha))
               .ForMember(dest => dest.TipoEscenario, act => act.MapFrom(src => src.TipoEscenario))
               .ForMember(dest => dest.Escenario, act => act.MapFrom(src => src.Escenario))
               .ForMember(dest => dest.Localizacion, act => act.MapFrom(src => src.Localizacion));
        }
    }
}
