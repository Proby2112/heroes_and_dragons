using AutoMapper;
using HeroesAndDragons.Core.ApiModels;
using HeroesAndDragons.Core.Entities;
using HeroesAndDragons.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesAndDragons.Mapper
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
}
