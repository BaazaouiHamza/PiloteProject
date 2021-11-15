using AutoMapper;
using HazemPFE.Dtos;
using HazemPFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HazemPFE.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //go to global.asax to initialise the mapping profile

            // Domain to Dto
            Mapper.CreateMap<Pilote, PiloteDto>();

            // Dto to Domain
            Mapper.CreateMap<PiloteDto, Pilote>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}