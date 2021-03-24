using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MemesProject.Models;

namespace MemesProject.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Main to DTO
            Mapper.CreateMap<MemeModel, MemeModel>();

            //DTO to Main

        }

    }
}