using AutoMapper;
using HeroesAndDragons.Core.ApiModels;
using HeroesAndDragons.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesAndDragons.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            // Dragon profile
            CreateMap<DragonEntity, DragonGetFullApiModel>();
            CreateMap<DragonEntity, DragonGetMinApiModel>();
            CreateMap<DragonAddApiModel, DragonEntity>();

            // Hero profile
            CreateMap<HeroEntity, HeroGetFullApiModel>();
            CreateMap<HeroEntity, HeroGetMinApiModel>();
            CreateMap<HeroAddApiModel, HeroEntity>();

            // Hit profile
            CreateMap<HitEntity, HitGetFullApiModel>();
            CreateMap<HitEntity, HitGetMinApiModel>();
            CreateMap<HitAddApiModel, HitEntity>();

        }
    }
}
