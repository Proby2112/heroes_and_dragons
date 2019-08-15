using AutoMapper;
using HeroesAndDragons.Core.ApiModels;
using HeroesAndDragons.Core.Entities;
using HeroesAndDragons.Core.Interfaces.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesAndDragons.Managers
{
    public class DataAdapter : IDataAdapter
    {
        readonly IMapper _mapper;

        public DataAdapter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public To Parse<From, To>(From model) => _mapper.Map<From, To>(model);

        public IEnumerable<To> Parse<From, To>(IEnumerable<From> models) => models.Select(Parse<From, To>).ToList();
    }

    class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            // Dragon profile
            CreateMap<DragonEntity, DragonGetFullApiModel>();
            CreateMap<DragonEntity, DragonGetMinApiModel>();
            CreateMap<DragonAddApiModel, DragonEntity>()
                .ForPath(de => de.CurrentHp, mo => mo.MapFrom(dm => dm.Hp))
                .ForPath(de => de.Created, mo => mo.Ignore());

            // Hero profile
            CreateMap<HeroEntity, HeroGetFullApiModel>();
            CreateMap<HeroEntity, HeroGetMinApiModel>();
            CreateMap<HeroAddApiModel, HeroEntity>()
                .ForPath(he => he.Created, mo => mo.Ignore());

            // Hit profile
            CreateMap<HitEntity, HitGetFullApiModel>();
            CreateMap<HitEntity, HitGetMinApiModel>();
            CreateMap<HitAddApiModel, HitEntity>()
                .ForPath(he => he.Created, mo => mo.Ignore());

        }
    }
}
