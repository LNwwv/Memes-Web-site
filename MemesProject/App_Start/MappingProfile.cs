using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MemesProject.Dto;
using MemesProject.Models;

namespace MemesProject.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Main to DTO
            Mapper.CreateMap<MemeModel, MemeDto>();

            //DTO to Main
            Mapper.CreateMap<MemeDto,MemeModel>()
                .ForMember(c => c.Id, opt => opt.Ignore()); ;
        }

    }
}